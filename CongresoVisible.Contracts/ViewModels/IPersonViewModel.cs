using CongresoVisible.Contracts.Common;
using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface IPersonViewModel : IServiceLocator, INavigateViewModel
    {
        string Url { get; set; }
        string Name { get; set; }
        string WebUrl { get; set; }
        int ListNumber { get; set; }
        string CandidateFor { get; set; }
        string Gender { get; set; }
        IPartyViewModel Party { get; set; }
        List<ITopicViewModel> TopicPositions { get; set; }
        //Images
        string SmallImage { get; set; }
        string MediumImage { get; set; }
        string OriginalImage { get; set; }
        //Biografy
        string ProfessionalExperience { get; set; }
        string BornDate { get; set; }
        List<ITopicViewModel> SupportedTopics { get; set; }
        //Trayectory
        int YearsInCongress { get; set; }
        int PoliticControlSummonses { get; set; }
        List<ITopicViewModel> MainTopics { get; set; }
        int PresentedProjects { get; set; }

        //Roaming
        DateTime? SincronizationDate { get; set; }

        //Commands
        ICommand ShowProfileCommand { get; }
        ICommand ShareProfileCommand { get; }
        ICommand FollowPersonCommand { get; }
        ICommand UnfollowPersonCommand { get; }
    }
}
