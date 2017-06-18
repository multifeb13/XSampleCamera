using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;

namespace XSampleCamera
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            InitializeComponent( );

            btn1.Clicked += async ( sender, args ) =>
            {
                await CrossMedia.Current.Initialize( );

                if( !CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported )
                {
                    DisplayAlert( "No Camera", ":( No camera available.", "OK" );
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync( new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg",
                    SaveToAlbum = true,
                } );

                if( file == null )
                    return;

                await DisplayAlert( "File Location", file.Path, "OK" );
                /*
                image.Source = ImageSource.FromStream( () =>
                {
                    var stream = file.GetStream( );
                    file.Dispose( );
                    return stream;
                } );
                */
            };
        }
	}
}
