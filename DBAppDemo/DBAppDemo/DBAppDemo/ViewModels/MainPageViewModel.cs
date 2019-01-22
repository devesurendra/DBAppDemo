using DBAppDemo.Services;
using DBAppDemo.Tables;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBAppDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private Member memberElement;

        private IMemberService memberService { get; }
        private IPageDialogService _dialogService;

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _age;
        public string Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        public DelegateCommand InsertCommand { get; private set; }
        public DelegateCommand ShowCommand { get; private set; }

        public MainPageViewModel(IMemberService memberService, INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            Title = "Main Page";
            this.memberService = memberService;
            _dialogService = dialogService;

            InsertCommand = new DelegateCommand(InsertRecord);
            ShowCommand = new DelegateCommand(ShowRecords);
        }

        private void ShowRecords()
        {
            throw new NotImplementedException();
        }

        private void InsertRecord()
        {
            memberElement = new Member();
            memberElement.Name = Name;
            memberElement.Age = Age;
            string result = this.memberService.AddMember(memberElement);
            _dialogService.DisplayAlertAsync("Alert", result, "Ok");
        }
    }
}
