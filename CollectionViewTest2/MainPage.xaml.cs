using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace CollectionViewTest2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        public class ROW
        {
            public string FIELD1 { get; set; }
            public string FIELD2 { get; set; }
            public string FIELD3 { get; set; }
            public string FIELD4 { get; set; }
            public string FIELD5 { get; set; }

        }

        public ObservableCollection<ROW> ROWS = new ObservableCollection<ROW>();

        private void btn_fill_Clicked(object sender, EventArgs e)
        {

            for (int i = 0; i < 1000; i++)
                ROWS.Add(new ROW()
                {
                    FIELD1 = Guid.NewGuid().ToString(),
                    FIELD2 = Guid.NewGuid().ToString(),
                    FIELD3 = Guid.NewGuid().ToString(),
                    FIELD4 = Guid.NewGuid().ToString(),
                    FIELD5 = Guid.NewGuid().ToString(),
                });


            view.ItemTemplate = new DataTemplate(() =>
            {
                Grid g = new Grid();
                g.RowDefinitions.Add(new RowDefinition(new GridLength(50)));
                g.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(50)));
                g.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(100)));
                g.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(200)));
                g.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(300)));
                g.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(100)));

                g.Add(new CheckBox(), 0, 0);
                Label labelFIELD1 = new Label();
                Label labelFIELD2 = new Label();
                Label labelFIELD3 = new Label();
                Label labelFIELD4 = new Label();
                Label labelFIELD5 = new Label();
                labelFIELD1.SetBinding(Label.TextProperty, "FIELD1");
                labelFIELD2.SetBinding(Label.TextProperty, "FIELD2");
                labelFIELD3.SetBinding(Label.TextProperty, "FIELD3");
                labelFIELD4.SetBinding(Label.TextProperty, "FIELD4");
                labelFIELD5.SetBinding(Label.TextProperty, "FIELD5");
                g.Add(labelFIELD1, 1, 0);
                g.Add(labelFIELD2, 2, 0);
                g.Add(labelFIELD3, 3, 0);
                g.Add(labelFIELD4, 4, 0);
                g.Add(labelFIELD5, 5, 0);

                return g;

            });

            view.ItemsSource = ROWS;
        }




    }
}
