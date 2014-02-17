using Autofac;
using CongresoVisible.Services.Contracts;
using Infrastructure.Common;
using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CongresoVisible.ViewModels
{
    public class PersonViewModel : BindableBase
    {
        ISocialService socialService;
        ILocalDataService localDataService;

        public PersonViewModel()
        {
            this.socialService = GetService<ISocialService>();
            this.localDataService = GetService<ILocalDataService>();

            this.shareProfileCommand = new RelayCommand(ShareProfile, null);
            this.followPersonCommand = new RelayCommand(FollowPerson, null);
            this.unfollowPersonCommand = new RelayCommand(UnfollowPerson, null);
        }

        #region ShareProfile
        private RelayCommand shareProfileCommand;

        public ICommand ShareProfileCommand
        {
            get { return this.shareProfileCommand; }
        }

        private void ShareProfile()
        {
            string message = string.Format("{0}", this.name);
            Uri uri = new Uri(this.WebUrl, UriKind.Absolute);
            socialService.ShareLink("None yet", message, uri);            
        }
        #endregion ShareProfile

        #region FollowPerson
        private RelayCommand followPersonCommand;

        public ICommand FollowPersonCommand
        {
            get { return this.shareProfileCommand; }
        }

        private void FollowPerson()
        {
            
        }
        #endregion FollowPerson

        #region UnfollowPerson
        private RelayCommand unfollowPersonCommand;

        public ICommand UnfollowPersonCommand
        {
            get { return this.unfollowPersonCommand; }
        }

        private void UnfollowPerson()
        {

        }
        #endregion UnfollowPerson

        #region Properties
        private string url = string.Empty;
        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.Set<string>(ref url, value);
            }
        }

        private string name = string.Empty;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.Set<string>(ref name, value);
            }
        }

        private string webUrl = string.Empty;
        public string WebUrl
        {
            get
            {
                return this.webUrl;
            }
            set
            {
                this.Set<string>(ref webUrl, value);
            }
        }

        private int listNumber = 0;
        public int ListNumber
        {
            get
            {
                return listNumber;
            }
            set
            {
                this.Set<int>(ref listNumber, value);
            }
        }

        private string candidateFor = string.Empty;
        public string CandidateFor
        {
            get
            {
                return this.candidateFor;
            }
            set
            {
                this.Set<string>(ref candidateFor, value);
            }
        }

        private string gender = string.Empty;
        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.Set<string>(ref gender, value);
            }
        }

        private PartyViewModel party;
        public PartyViewModel Party
        {
            get
            {
                return this.party;
            }
            set
            {
                this.Set<PartyViewModel>(ref party, value);
            }
        }

        private string smallImage = string.Empty;
        public string SmallImage
        {
            get
            {
                return this.smallImage;
            }
            set
            {
                this.Set<string>(ref smallImage, value);
            }
        }

        private string mediumImage = string.Empty;
        public string MediumImage
        {
            get
            {
                return this.mediumImage;
            }
            set
            {
                this.Set<string>(ref mediumImage, value);
            }
        }

        private string originalImage = string.Empty;
        public string OriginalImage
        {
            get
            {
                return this.originalImage;
            }
            set
            {
                this.Set<string>(ref originalImage, value);
            }
        }

        private string professionalExperience = string.Empty;
        public string ProfessionalExperience
        {
            get
            {
                return this.professionalExperience;
            }
            set
            {
                this.Set<string>(ref professionalExperience, value);
            }
        }

        private string bornDate = string.Empty;
        public string BornDate
        {
            get
            {
                return this.bornDate;
            }
            set
            {
                this.Set<string>(ref bornDate, value);
            }
        }

        private ObservableCollection<TopicViewModel> supportedTopics;
        public ObservableCollection<TopicViewModel> SupportedTopics
        {
            get
            {
                return this.supportedTopics;
            }
            set
            {
                this.Set<ObservableCollection<TopicViewModel>>(ref supportedTopics, value);
            }
        }

        private int yearsInCongress = 0;
        public int YearsInCongress
        {
            get
            {
                return this.yearsInCongress;
            }
            set
            {
                this.Set<int>(ref yearsInCongress, value);
            }
        }

        private int politicControlSummonses = 0;
        public int PoliticControlSummonses
        {
            get
            {
                return this.politicControlSummonses;
            }
            set
            {
                this.Set<int>(ref politicControlSummonses, value);
            }
        }

        private int presentedProjects = 0;
        public int PresentedProjects
        {
            get
            {
                return this.presentedProjects;
            }
            set
            {
                this.Set<int>(ref presentedProjects, value);
            }
        }

        private DateTime? sincronizationDate;
        public DateTime? SincronizationDate
        {
            get
            {
                return this.sincronizationDate;
            }
            set
            {
                this.Set<DateTime?>(ref sincronizationDate, value);
            }
        }

        private ObservableCollection<TopicViewModel> topicPositions;
        public ObservableCollection<TopicViewModel> TopicPositions
        {
            get
            {
                return this.topicPositions;
            }
            set
            {
                this.Set<ObservableCollection<TopicViewModel>>(ref topicPositions, value);
            }
        }

        private ObservableCollection<TopicViewModel> mainTopics;
        public ObservableCollection<TopicViewModel> MainTopics
        {
            get
            {
                return this.mainTopics;
            }
            set
            {
                this.Set<ObservableCollection<TopicViewModel>>(ref mainTopics, value);
            }
        }
        #endregion properties

        public ICommand ShowProfileCommand
        {
            get { throw new NotImplementedException(); }
        }
    }
}
