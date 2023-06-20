using System;
using System.IO;
using System.Linq;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Plugin.Media.Abstractions;

namespace Qloudid.Views.Repair
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportTheProblemPage : ContentPage
    {
        #region Variables.
        private IMedia _mediaPicker;
        ImageSource _imageSource;
        ReportTheProblemPageViewModel viewModel;
        #endregion

        #region Constructor.
        public ReportTheProblemPage(Models.UserApartmentProblemDetailResponse userApartment)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ReportTheProblemPageViewModel(this.Navigation);
            viewModel.SelectedApartmentProblemDetail = userApartment;
            viewModel.GetTicketSubTitleInfoCommand.Execute(null);
        }
        #endregion

        #region Setup.
        private async void Setup()
        {
            if (_mediaPicker != null) return;
            await CrossMedia.Current.Initialize();
            _mediaPicker = CrossMedia.Current;
        }
        #endregion

        #region Take Photo.
        private async Task TakePhoto(int selectedImage)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }
            Setup();
            _imageSource = null;
            try
            {
                var mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    CompressionQuality = 90,
                });

                if (mediaFile != null)
                {
                    switch (selectedImage)
                    {
                        case 1:
                            img1.Source = ImageSource.FromStream(mediaFile.GetStream);
                            viewModel.Image_1 = true;
                            break;
                        case 2:
                            img2.Source = ImageSource.FromStream(mediaFile.GetStream);
                            viewModel.Image_2 = true;
                            break;
                        case 3:
                            img3.Source = ImageSource.FromStream(mediaFile.GetStream);
                            viewModel.Image_3 = true;
                            break;
                        case 4:
                            img4.Source = ImageSource.FromStream(mediaFile.GetStream);
                            viewModel.Image_4 = true;
                            break;
                        case 5:
                            img5.Source = ImageSource.FromStream(mediaFile.GetStream);
                            viewModel.Image_5 = true;
                            break;
                        case 6:
                            img6.Source = ImageSource.FromStream(mediaFile.GetStream);
                            viewModel.Image_6 = true;
                            break;
                        case 7:
                            img7.Source = ImageSource.FromStream(mediaFile.GetStream);
                            viewModel.Image_7 = true;
                            break;
                        case 8:
                            img8.Source = ImageSource.FromStream(mediaFile.GetStream);
                            viewModel.Image_8 = true;
                            break;
                        case 9:
                            img9.Source = ImageSource.FromStream(mediaFile.GetStream);
                            viewModel.Image_9 = true;
                            break;
                    }

                    var stream = mediaFile.GetStream();
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        byte[] imageAsByte = memoryStream.ToArray();
                        byte[] aa = await DependencyService.Get<Interfaces.IImageResizerService>().ResizeImage(imageAsByte, 600, 500);
                        if (viewModel.ImageDataInfo == null)
                            viewModel.ImageDataInfo = new List<ImageData>();
                        var data = viewModel.ImageDataInfo.FirstOrDefault(x => x.ImageId.Equals(selectedImage));
                        if (data != null)
                        {
                            data.ImageBytes = aa;
                        }
                        else
                        {
                            viewModel.ImageDataInfo.Add(new ImageData()
                            {
                                ImageBytes = aa,
                                ImageId = selectedImage,
                            });
                        }
                    }

                    /*(imgUser.Source = ImageSource.FromStream(mediaFile.GetStream);
                    var memoryStream = new MemoryStream();
                    await mediaFile.GetStream().CopyToAsync(memoryStream);
                    byte[] imageAsByte = memoryStream.ToArray();
                    viewModel.UserImageData = imageAsByte;*/
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Pick Multiple Images.
        private async Task SelectImages(int selectedImage)
        {
            try
            {
                var result = await FilePicker.PickMultipleAsync(new PickOptions()
                {
                    FileTypes = FilePickerFileType.Images
                });
                if (result != null)
                {
                    List<ImageSource> list = new List<ImageSource>();
                    foreach (var item in result)
                    {
                        var stream = await item.OpenReadAsync();
                        list.Add(ImageSource.FromStream(() => stream));
                    }

                    switch (selectedImage)
                    {
                        case 1:
                            switch (list.Count())
                            {
                                case 1:
                                    img1.Source = list[0];
                                    viewModel.Image_1 = true;
                                    break;
                                case 2:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    break;
                                case 3:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    break;
                                case 4:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    break;
                                case 5:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    break;
                                case 6:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    img6.Source = list[5];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    break;
                                case 7:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    img6.Source = list[5];
                                    img7.Source = list[6];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 8:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    img6.Source = list[5];
                                    img7.Source = list[6];
                                    img8.Source = list[7];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 9:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    img6.Source = list[5];
                                    img7.Source = list[6];
                                    img8.Source = list[7];
                                    img9.Source = list[8];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img1.Source = list[0];
                                    img2.Source = list[1];
                                    img3.Source = list[2];
                                    img4.Source = list[3];
                                    img5.Source = list[4];
                                    img6.Source = list[5];
                                    img7.Source = list[6];
                                    img8.Source = list[7];
                                    img9.Source = list[8];
                                    viewModel.Image_1 = true;
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 2:
                            switch (list.Count())
                            {
                                case 1:
                                    img2.Source = list[0];
                                    viewModel.Image_2 = true;
                                    break;
                                case 2:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    break;
                                case 3:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    break;
                                case 4:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    break;
                                case 5:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    img6.Source = list[4];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    break;
                                case 6:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    img6.Source = list[4];
                                    img7.Source = list[5];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 7:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    img6.Source = list[4];
                                    img7.Source = list[5];
                                    img8.Source = list[6];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 8:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    img6.Source = list[4];
                                    img7.Source = list[5];
                                    img8.Source = list[6];
                                    img9.Source = list[7];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img2.Source = list[0];
                                    img3.Source = list[1];
                                    img4.Source = list[2];
                                    img5.Source = list[3];
                                    img6.Source = list[4];
                                    img7.Source = list[5];
                                    img8.Source = list[6];
                                    img9.Source = list[7];
                                    viewModel.Image_2 = true;
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 3:
                            switch (list.Count())
                            {
                                case 1:
                                    img3.Source = list[0];
                                    viewModel.Image_3 = true;
                                    break;
                                case 2:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    break;
                                case 3:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    break;
                                case 4:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    img6.Source = list[3];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    break;
                                case 5:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    img6.Source = list[3];
                                    img7.Source = list[4];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 6:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    img6.Source = list[3];
                                    img7.Source = list[4];
                                    img8.Source = list[5];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 7:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    img6.Source = list[3];
                                    img7.Source = list[4];
                                    img8.Source = list[5];
                                    img9.Source = list[6];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img3.Source = list[0];
                                    img4.Source = list[1];
                                    img5.Source = list[2];
                                    img6.Source = list[3];
                                    img7.Source = list[4];
                                    img8.Source = list[5];
                                    img9.Source = list[6];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 4:
                            switch (list.Count())
                            {
                                case 1:
                                    img4.Source = list[0];
                                    viewModel.Image_4 = true;
                                    break;
                                case 2:
                                    img4.Source = list[0];
                                    img5.Source = list[1];
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    break;
                                case 3:
                                    img4.Source = list[0];
                                    img5.Source = list[1];
                                    img6.Source = list[2];
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    break;
                                case 4:
                                    img4.Source = list[0];
                                    img5.Source = list[1];
                                    img6.Source = list[2];
                                    img7.Source = list[3];
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 5:
                                    img5.Source = list[1];
                                    img6.Source = list[2];
                                    img7.Source = list[3];
                                    img8.Source = list[4];
                                    viewModel.Image_3 = true;
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 6:
                                    img4.Source = list[0];
                                    img5.Source = list[1];
                                    img6.Source = list[2];
                                    img7.Source = list[3];
                                    img8.Source = list[4];
                                    img9.Source = list[5];
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img4.Source = list[0];
                                    img5.Source = list[1];
                                    img6.Source = list[2];
                                    img7.Source = list[3];
                                    img8.Source = list[4];
                                    img9.Source = list[5];
                                    viewModel.Image_4 = true;
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 5:
                            switch (list.Count())
                            {
                                case 1:
                                    img5.Source = list[0];
                                    viewModel.Image_5 = true;
                                    break;
                                case 2:
                                    img5.Source = list[0];
                                    img6.Source = list[1];
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    break;
                                case 3:
                                    img5.Source = list[0];
                                    img6.Source = list[1];
                                    img7.Source = list[2];
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 4:
                                    img5.Source = list[0];
                                    img6.Source = list[1];
                                    img7.Source = list[2];
                                    img8.Source = list[3];
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 5:
                                    img5.Source = list[0];
                                    img6.Source = list[1];
                                    img7.Source = list[2];
                                    img8.Source = list[3];
                                    img9.Source = list[4];
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img5.Source = list[0];
                                    img6.Source = list[1];
                                    img7.Source = list[2];
                                    img8.Source = list[3];
                                    img9.Source = list[4];
                                    viewModel.Image_5 = true;
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 6:
                            switch (list.Count())
                            {
                                case 1:
                                    img6.Source = list[0];
                                    viewModel.Image_6 = true;
                                    break;
                                case 2:
                                    img6.Source = list[0];
                                    img7.Source = list[1];
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    break;
                                case 3:
                                    img6.Source = list[0];
                                    img7.Source = list[1];
                                    img8.Source = list[2];
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 4:
                                    img6.Source = list[0];
                                    img7.Source = list[1];
                                    img8.Source = list[2];
                                    img9.Source = list[3];
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img6.Source = list[0];
                                    img7.Source = list[1];
                                    img8.Source = list[2];
                                    img9.Source = list[3];
                                    viewModel.Image_6 = true;
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 7:
                            switch (list.Count())
                            {
                                case 1:
                                    img7.Source = list[0];
                                    viewModel.Image_7 = true;
                                    break;
                                case 2:
                                    img7.Source = list[0];
                                    img8.Source = list[1];
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    break;
                                case 3:
                                    img7.Source = list[0];
                                    img8.Source = list[1];
                                    img9.Source = list[2];
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img7.Source = list[0];
                                    img8.Source = list[1];
                                    img9.Source = list[2];
                                    viewModel.Image_7 = true;
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 8:
                            switch (list.Count())
                            {
                                case 1:
                                    img8.Source = list[0];
                                    viewModel.Image_8 = true;
                                    break;
                                case 2:
                                    img8.Source = list[0];
                                    img9.Source = list[1];
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img8.Source = list[0];
                                    img9.Source = list[1];
                                    viewModel.Image_8 = true;
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                        case 9:
                            switch (list.Count())
                            {
                                case 1:
                                    img9.Source = list[0];
                                    viewModel.Image_9 = true;
                                    break;
                                default:
                                    img9.Source = list[0];
                                    viewModel.Image_9 = true;
                                    break;
                            }
                            break;
                    }

                    int index = selectedImage;
                    foreach (var imageStream in result)
                    {
                        var stream = await imageStream.OpenReadAsync();
                        using (var memoryStream = new MemoryStream())
                        {
                            await stream.CopyToAsync(memoryStream);
                            byte[] imageAsByte = memoryStream.ToArray();
                            byte[] aa = await DependencyService.Get<Interfaces.IImageResizerService>().ResizeImage(imageAsByte, 600, 500);
                            if (viewModel.ImageDataInfo == null)
                                viewModel.ImageDataInfo = new List<ImageData>();
                            var data = viewModel.ImageDataInfo.FirstOrDefault(x => x.ImageId.Equals(index));
                            if (data != null)
                            {
                                data.ImageBytes = aa;
                            }
                            else
                            {
                                viewModel.ImageDataInfo.Add(new ImageData()
                                {
                                    ImageBytes = aa,
                                    ImageId = index,
                                });
                            }
                            index = index + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
        }
        #endregion

        #region On Image Clicked.
        private async void OnImg1Clicked(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
            switch (result)
            {
                case "Take Photo":
                    await TakePhoto(1);
                    break;
                case "Pick Photo":
                    await SelectImages(1);
                    break;
            }
        }

        private async void OnImg2Clicked(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
            switch (result)
            {
                case "Take Photo":
                    await TakePhoto(2);
                    break;
                case "Pick Photo":
                    await SelectImages(2);
                    break;
            }
        }

        private async void OnImg3Clicked(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
            switch (result)
            {
                case "Take Photo":
                    await TakePhoto(3);
                    break;
                case "Pick Photo":
                    await SelectImages(3);
                    break;
            }
        }

        private async void OnImg4Clicked(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
            switch (result)
            {
                case "Take Photo":
                    await TakePhoto(4);
                    break;
                case "Pick Photo":
                    await SelectImages(4);
                    break;
            }
        }

        private async void OnImg5Clicked(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
            switch (result)
            {
                case "Take Photo":
                    await TakePhoto(5);
                    break;
                case "Pick Photo":
                    await SelectImages(5);
                    break;
            }
        }

        private async void OnImg6Clicked(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
            switch (result)
            {
                case "Take Photo":
                    await TakePhoto(6);
                    break;
                case "Pick Photo":
                    await SelectImages(6);
                    break;
            }
        }

        private async void OnImg7Clicked(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
            switch (result)
            {
                case "Take Photo":
                    await TakePhoto(7);
                    break;
                case "Pick Photo":
                    await SelectImages(7);
                    break;
            }
        }

        private async void OnImg8Clicked(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
            switch (result)
            {
                case "Take Photo":
                    await TakePhoto(8);
                    break;
                case "Pick Photo":
                    await SelectImages(8);
                    break;
            }
        }

        private async void OnImg9Clicked(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Select", "Cancel", null, "Take Photo", "Pick Photo");
            switch (result)
            {
                case "Take Photo":
                    await TakePhoto(9);
                    break;
                case "Pick Photo":
                    await SelectImages(9);
                    break;
            }
        }
        #endregion

        #region Selected Image Remove.
        private void OnImg1RemovedTapped(object sender, EventArgs e)
        {
            img1.Source = null;
            viewModel.Image_1 = false;
            viewModel.ImageDataInfo.RemoveAll(x => x.ImageId == 1);
        }

        private void OnImg2RemovedTapped(object sender, EventArgs e)
        {
            img2.Source = null;
            viewModel.Image_2 = false;
            viewModel.ImageDataInfo.RemoveAll(x => x.ImageId == 2);
        }

        private void OnImg3RemovedTapped(object sender, EventArgs e)
        {
            img3.Source = null;
            viewModel.Image_3 = false;
            viewModel.ImageDataInfo.RemoveAll(x => x.ImageId == 3);
        }

        private void OnImg4RemovedTapped(object sender, EventArgs e)
        {
            img4.Source = null;
            viewModel.Image_4 = false;
            viewModel.ImageDataInfo.RemoveAll(x => x.ImageId == 4);
        }

        private void OnImg5RemovedTapped(object sender, EventArgs e)
        {
            img5.Source = null;
            viewModel.Image_5 = false;
            viewModel.ImageDataInfo.RemoveAll(x => x.ImageId == 5);
        }

        private void OnImg6RemovedTapped(object sender, EventArgs e)
        {
            img6.Source = null;
            viewModel.Image_6 = false;
            viewModel.ImageDataInfo.RemoveAll(x => x.ImageId == 6);
        }

        private void OnImg7RemovedTapped(object sender, EventArgs e)
        {
            img7.Source = null;
            viewModel.Image_7 = false;
            viewModel.ImageDataInfo.RemoveAll(x => x.ImageId == 7);
        }

        private void OnImg8RemovedTapped(object sender, EventArgs e)
        {
            img8.Source = null;
            viewModel.Image_8 = false;
            viewModel.ImageDataInfo.RemoveAll(x => x.ImageId == 8);
        }

        private void OnImg9RemovedTapped(object sender, EventArgs e)
        {
            img9.Source = null;
            viewModel.Image_9 = false;
            viewModel.ImageDataInfo.RemoveAll(x => x.ImageId == 9);
        }
        #endregion

        #region On Problem Type Clicked.
        private void OnProblemTypeLabelClicked(object sender, EventArgs e)
        {
            Label control = sender as Label;
            OnProblemTypeClicked(control.BindingContext as Models.TicketSubTitleIssueInfoResponse);
        }

        private void OnProblemTypeButtonClicked(object sender, EventArgs e)
        {
            Button control = sender as Button;
            OnProblemTypeClicked(control.BindingContext as Models.TicketSubTitleIssueInfoResponse);
        }

        void OnProblemTypeClicked(Models.TicketSubTitleIssueInfoResponse ticketSubTitleIssue)
        {
            ticketSubTitleIssue.IsSelected = !ticketSubTitleIssue.IsSelected;
        }
        #endregion
    }
}
