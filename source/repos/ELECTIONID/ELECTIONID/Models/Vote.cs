using System;
using System.Collections.Generic;

#nullable disable

namespace ELECTIONID.Models
{
    public partial class Vote
    {
        public Vote()
        {
          
        }

        public int VoteId { get; set; }
     
      
        public int ElecteurId { get; set; }
        public virtual Electeur Electeur { get; set; }
     
    }
}
