using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAL.Model
{
    #region workflow
    //-------------------------------------------------
    //-------------------------------------------------
    public class WorkflowPending
    {
        public string Task_ID { get; set; }
        public bool select { get; set; }
        public string customer { get; set; }
        public string agreement { get; set; }
        public string site { get; set; }
        public string NumofEquipment { get; set; }
        public string JobType { get; set; }
        public string LoggedBy { get; set; }
    }

    public class WorkflowInProgress
    {
        public string Task_ID { get; set; }
        public bool select { get; set; }
        public string customer { get; set; }
        public string agreement { get; set; }
        public string site { get; set; }
        public string JobType { get; set; }
        public string NumofEquipment { get; set; }
        public string AssignmentSynchStatu { get; set; }
    }

    public class WorkflowComplete
    {
        public string Task_ID { get; set; }
        public bool select { get; set; }
        public string customer { get; set; }
        public string agreement { get; set; }
        public string site { get; set; }
        public string JobType { get; set; }
        public string Expected_dates { get; set; }
        public string ActualDates { get; set; }
        public bool problem_exist { get; set; }
        public string Report { get; set; }
    }

    public class WorkflowModel
    {
        public IList<WorkflowPending> PendingList = new List<WorkflowPending>();
        //------------------------------
        public void AddPendingList(WorkflowPending obj)
        {
            this.PendingList.Add(obj);
        }

        public IList<WorkflowInProgress> ProgressList = new List<WorkflowInProgress>();
        //------------------------------
        public void AddProgressList(WorkflowInProgress obj)
        {
            this.ProgressList.Add(obj);
        }

        public IList<WorkflowComplete> CompleteList = new List<WorkflowComplete>();
        //------------------------------
        public void AddCompleteList(WorkflowComplete obj)
        {
            this.CompleteList.Add(obj);
        }
    }

    #endregion
}