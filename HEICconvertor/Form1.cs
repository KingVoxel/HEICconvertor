using ImageMagick;

namespace HEICconvertor
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? _cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            btnGo.Enabled = false;

            try
            {
                string iconPath = Path.Combine(Application.StartupPath, "atarilogo_Wfh_icon.ico");
                if (File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading icon: {ex.Message}");
            }
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtInputFolder.Text = dialog.SelectedPath;
                    txtOutputFolder.Text = Path.Combine(dialog.SelectedPath, "outputJPGs");
                    ValidateInputs();
                }
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtOutputFolder.Text = dialog.SelectedPath;
                    ValidateInputs();
                }
            }
        }

        private void ValidateInputs()
        {
            btnGo.Enabled = !string.IsNullOrWhiteSpace(txtInputFolder.Text) &&
                           !string.IsNullOrWhiteSpace(txtOutputFolder.Text);
        }

        private void txtInputFolder_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtInputFolder.Text))
            {
                txtOutputFolder.Text = Path.Combine(txtInputFolder.Text, "outputJPGs");
            }
            ValidateInputs();
        }

        private void txtOutputFolder_TextChanged(object sender, EventArgs e)
        {
            ValidateInputs();
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                btnGo.Enabled = false;
                btnBrowseInput.Enabled = false;
                btnBrowseOutput.Enabled = false;
                progressBar.Value = 0;

                _cancellationTokenSource = new CancellationTokenSource();

                var inputDir = txtInputFolder.Text;
                var outputDir = txtOutputFolder.Text;

                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                var heicFiles = Directory.GetFiles(inputDir, "*.heic", SearchOption.AllDirectories);
                var totalFiles = heicFiles.Length;

                if (totalFiles == 0)
                {
                    MessageBox.Show("No HEIC files found in the input directory.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                progressBar.Maximum = totalFiles;
                var convertedCount = 0;

                await Task.Run(() =>
                {
                    Parallel.ForEach(heicFiles, new ParallelOptions
                    {
                        MaxDegreeOfParallelism = Environment.ProcessorCount,
                        CancellationToken = _cancellationTokenSource.Token
                    }, (heicFile) =>
                    {
                        var relativePath = Path.GetRelativePath(inputDir, heicFile);
                        var outputPath = Path.Combine(outputDir,
                            Path.ChangeExtension(relativePath, ".jpg"));

                        var outputDirectory = Path.GetDirectoryName(outputPath);
                        if (!Directory.Exists(outputDirectory))
                        {
                            Directory.CreateDirectory(outputDirectory);
                        }

                        using (var image = new MagickImage(heicFile))
                        {
                            image.Quality = 90;
                            image.Write(outputPath);
                        }

                        Interlocked.Increment(ref convertedCount);
                        this.Invoke(() => progressBar.Value = convertedCount);
                    });
                }, _cancellationTokenSource.Token);

                MessageBox.Show($"Successfully converted {convertedCount} files!", "Conversion Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Operation was cancelled.", "Cancelled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
                progressBar.Value = 0;
                btnGo.Enabled = true;
                btnBrowseInput.Enabled = true;
                btnBrowseOutput.Enabled = true;
            }
        }
    }
}