using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeApp.Models
{
    public class Resume
    {
        public BasicInformationModel BasicInformationModel { get; set; }
        public List<SkillsModel> SkillsModel { get; set; }
        public List<LanguagesModel> LanguagesModel { get; set; }
        public List<ExperinceModel> ExperinceModel { get; set; }
        public List<educationModel> educationModel { get; set; }
        public summeryModel summeryModel { get; set; }
    }
}