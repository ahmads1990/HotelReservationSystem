using FOOD_APP_JSB_2.Data.Enums;
using System.Collections.Generic;

namespace FOOD_APP_JSB_2.Models
{
    public class UserFeature : BaseModel
    {
        public int UserID { get; set; }
        public User user  { get; set; }
        public Feature Feature { get; set; }
    }
}
