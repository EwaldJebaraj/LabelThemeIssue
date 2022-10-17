namespace LabelThemeIssue;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        LoadTheme();
        App.Current.RequestedThemeChanged += Current_RequestedThemeChanged;
    }

    private void Current_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        LoadTheme();
    }

    void LoadTheme()

    {
        var applicationResourceDictionary = App.Current.Resources;
        var theme = App.Current.RequestedTheme;
        switch (theme)

        {
            case AppTheme.Dark:

                ManuallyCopyThemes(new Resources.Styles.DarkTheme(), applicationResourceDictionary);
                break;
                
            default:
                ManuallyCopyThemes(new Resources.Styles.LightTheme(), applicationResourceDictionary);

                break;


        }

    }



    void ManuallyCopyThemes(ResourceDictionary fromResource, ResourceDictionary toResource)

    {

        foreach (var item in fromResource.Keys)

        {

            if (toResource.ContainsKey(item))

                toResource[item] = fromResource[item];

            else

                toResource.Add(item, fromResource[item]);

        }

    }
}

