using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.Validation;
using Plugin.TextToSpeech;

namespace HelloWorldV2.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<IValidator, Validator>();

            Mvx.RegisterSingleton(CrossTextToSpeech.Current);

            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}
