using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StruCal.TrainLoad.App.DTO
{
    public class TrainLoadProgress
    {
        public TrainLoadProgress(Progress progress, bool hasResult)
        {
            Progress = (int)progress;
            HasResult = hasResult;
        }

        public TrainLoadProgress()
        {
        }

        public int Progress { get; set; }
        public bool HasResult { get; set; }
    }
}