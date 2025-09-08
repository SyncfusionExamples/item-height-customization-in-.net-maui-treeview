# item-height-customization-in-.net-maui-treeview
This repository demonstrates how to customize the item or node height at runtime in the .NET MAUI TreeView (SfTreeView) control. It provides a sample implementation using the QueryNodeSize event to dynamically adjust node sizes based on their content, enabling flexible and responsive layouts.

## Sample

### XAML

```xaml
<ContentPage.BindingContext>
    <local:FileManagerViewModel x:Name="viewModel"/>
</ContentPage.BindingContext>

<ContentPage.Content>
    <syncfusion:SfTreeView x:Name="treeView"
                            ChildPropertyName="SubFiles"
                            ItemsSource="{Binding ImageNodeInfo}"
                            AutoExpandMode="AllNodesExpanded">
        <syncfusion:SfTreeView.Behaviors>
            <local:Behavior/>
        </syncfusion:SfTreeView.Behaviors>
        <syncfusion:SfTreeView.ItemTemplate>
            <DataTemplate>
                <Grid RowSpacing="0" ColumnSpacing="0" Margin="0">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="1" />
                    </Grid.RowDefinitions>
                    <Grid RowSpacing="0" Padding="5">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <Image Source="{Binding ImageIcon}" Margin="0,5,5,0" Grid.Column="0" Grid.Row="0" HeightRequest="30" WidthRequest="30" HorizontalOptions="Start" VerticalOptions="Start" />
                        <StackLayout Padding="5,5,0,0" Orientation="Vertical" VerticalOptions="Center" Grid.Row="0" Grid.Column="1">
                            <Label Text="{Binding FileName}" FontFamily="Roboto" FontAttributes="Bold" FontSize="16" HeightRequest="30" VerticalTextAlignment="Center" TextColor="#474747"/>
                            <Label Text="{Binding FileDescription}" FontFamily="Roboto" LineHeight="1" Opacity=" 0.74" TextColor="#474747" FontSize="14"/>
                        </StackLayout>
                    </Grid>
                    <BoxView Grid.Row="1" Margin="0" HeightRequest="1" Opacity="0.24" BackgroundColor="#CECECE" />
                </Grid>
            </DataTemplate>
        </syncfusion:SfTreeView.ItemTemplate>
    </syncfusion:SfTreeView>
</ContentPage.Content>
```

### Behaviour

```csharp
public class Behavior :Behavior<SfTreeView>
{
    private SfTreeView sftreeView;

    protected override void OnAttachedTo(SfTreeView bindable)
    {
        sftreeView = bindable;
        sftreeView.QueryNodeSize += SftreeView_QueryNodeSize;
        base.OnAttachedTo(bindable);
    }

    private void SftreeView_QueryNodeSize(object sender, QueryNodeSizeEventArgs e)
    {
        // Returns item height based on the content loaded.
        e.Height = e.GetActualNodeHeight();
        e.Handled = true;
    }

    protected override void OnDetachingFrom(SfTreeView bindable)
    {
        sftreeView.QueryNodeSize -= SftreeView_QueryNodeSize;
        sftreeView = null;
        base.OnDetachingFrom(bindable);
    }
}
```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements).

Make sure that you have the compatible versions of [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/ ) with the Dot NET MAUI workload and [.NET Core SDK 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) or later version in your machine before starting to work on this project.

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.
