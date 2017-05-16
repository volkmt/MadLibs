using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Validation;
using Plugin.TextToSpeech.Abstractions;
using System.Windows.Input;

namespace HelloWorldV2.Core.ViewModels
{
    public class FirstViewModel: MvxViewModel
    {
        // Fields
        IValidator _validator;

        IMvxToastService _toastService;

        private readonly ITextToSpeech _textToSpeech;


        // Constructors
        public FirstViewModel(IValidator validator, IMvxToastService toastService, ITextToSpeech textToSpeech)
        {
            _validator = validator;
            _toastService = toastService;
            _textToSpeech = textToSpeech;

            ReadMadLibCommand = new MvxCommand(() => ReadMadLib());
        }


        // Properties
        public ICommand ReadMadLibCommand {get; private set;}
        
        [Required("Please provide a first name!")]
        public string FirstName { get; set; }
        
        [Required("Please provide a last name!")]
        public string LastName { get; set; }

        [Required("Please provide an action verb!")]
        public string ActionVerb { get; set; }

        [Required("Please provide a family member!")]
        public string FamilyMember { get; set; }

        [Required("Please provide a verb!")]
        public string Verb { get; set; }


        //Methods
        private void ReadMadLib()
        {
            var errors = _validator.Validate(this);

            var readThePhrase = $"Hello. My name is {FirstName} {LastName}." +
                $"You {ActionVerb} my {FamilyMember}. Prepare to {Verb}!";

            if (!errors.IsValid)
            {
                _toastService.DisplayErrors(errors);
                return;
            }

            _textToSpeech.Speak(readThePhrase);
        }
        
    }
}
