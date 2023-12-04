namespace ReproProjectForHtmlImage;

public partial class WebView : ContentPage
{
	public WebView()
	{
		InitializeComponent();
		_ = LoadData();
	}


	public async Task LoadData()
	{
        HtmlWebViewSource htmlText = await OnViewAppear();

        if (htmlText != null)
        {
            wv.Source = htmlText;
        }
    }

	async Task<HtmlWebViewSource> OnViewAppear()
	{
        using var stream = await FileSystem.OpenAppPackageFileAsync("testHtml.html");
        using var reader = new StreamReader(stream);

        var text = reader.ReadToEnd();

        var htmlText = new HtmlWebViewSource
        {
            Html = text
        };

        return htmlText;

    }


}