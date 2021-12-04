using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ELECTIONID.Models
{
    public partial class Candidat
    {
        public Candidat()
        {
            Electeurs = new HashSet<Electeur>();
        }

        public int CandidatId { get; set; }
        public string NomCandidat { get; set; }
        public string PrenomCandidat { get; set; }
        public string CinCandidat { get; set; }
        public string ImageCandidat { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public int? AdministrateurId { get; set; }

        public virtual Administrateur Administrateur { get; set; }
        public virtual ICollection<Electeur> Electeurs { get; set; }
    }
}
