using Autofac;
using CongresoVisible.Services.Contracts;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace CongresoVisible.ViewModels
{
    public class PersonViewModel : BindableBase
    {
        ISocialService socialService;
        IRoamingService roamingService;
        ILocalDataService localDataService;

        public PersonViewModel()
        {
            this.socialService = GetService<ISocialService>();
            this.roamingService = GetService<IRoamingService>();
            this.localDataService = GetService<ILocalDataService>();

            this.shareProfileCommand = new DelegateCommand(ShareProfile, null);
            this.followPersonCommand = new DelegateCommand(FollowPerson, null);
            this.unfollowPersonCommand = new DelegateCommand(UnfollowPerson, null);
        }

        #region ShareProfile
        private DelegateCommand shareProfileCommand;

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
        private DelegateCommand followPersonCommand;

        public ICommand FollowPersonCommand
        {
            get { return this.shareProfileCommand; }
        }

        private void FollowPerson()
        {
            
        }
        #endregion FollowPerson

        #region UnfollowPerson
        private DelegateCommand unfollowPersonCommand;

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
                this.SetProperty(ref url, value);
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
                this.SetProperty(ref name, value);
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
                this.SetProperty(ref webUrl, value);
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
                this.SetProperty(ref listNumber, value);
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
                this.SetProperty(ref candidateFor, value);
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
                this.SetProperty(ref gender, value);
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
                this.SetProperty(ref party, value);
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
                this.SetProperty(ref smallImage, value);
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
                this.SetProperty(ref mediumImage, value);
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
                this.SetProperty(ref originalImage, value);
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
                this.SetProperty(ref professionalExperience, value);
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
                this.SetProperty(ref bornDate, value);
            }
        }

        private List<TopicViewModel> supportedTopics;
        public List<TopicViewModel> SupportedTopics
        {
            get
            {
                return this.supportedTopics;
            }
            set
            {
                this.SetProperty(ref supportedTopics, value);
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
                this.SetProperty(ref yearsInCongress, value);
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
                this.SetProperty(ref politicControlSummonses, value);
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
                this.SetProperty(ref presentedProjects, value);
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
                this.SetProperty(ref sincronizationDate, value);
            }
        }

        private List<TopicViewModel> topicPositions;
        public List<TopicViewModel> TopicPositions
        {
            get
            {
                return this.topicPositions;
            }
            set
            {
                this.SetProperty(ref topicPositions, value);
            }
        }

        private List<TopicViewModel> mainTopics;
        public List<TopicViewModel> MainTopics
        {
            get
            {
                return this.mainTopics;
            }
            set
            {
                this.SetProperty(ref mainTopics, value);
            }
        }
        #endregion properties


        public ICommand ShowProfileCommand
        {
            get { throw new NotImplementedException(); }
        }
    }
}
