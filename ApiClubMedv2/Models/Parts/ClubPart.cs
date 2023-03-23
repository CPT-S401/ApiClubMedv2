namespace ApiClubMedv2.Models.EntityFramework
{
    public partial class Club
    {
        public override string? ToString()
        {
            return $"{this.Nom} {this.Email} {this.Description} ";
        }

        public override bool Equals(object? obj)
        {
            return obj is Club club &&
                   this.Id == club.Id &&
                   this.IdDomaineSkiable == club.IdDomaineSkiable &&
                   this.Nom == club.Nom &&
                   this.Description == club.Description &&
                   this.LienPDF == club.LienPDF &&
                   this.Longitude == club.Longitude &&
                   this.Latitude == club.Latitude &&
                   this.Email == club.Email &&
                   EqualityComparer<DomaineSkiable?>.Default.Equals(this.Domaine, club.Domaine) &&
                   EqualityComparer<ICollection<ClubMultimedia>>.Default.Equals(this.ClubMultimedias, club.ClubMultimedias) &&
                   EqualityComparer<ICollection<ClubTransport>>.Default.Equals(this.ClubTransports, club.ClubTransports) &&
                   EqualityComparer<ICollection<ClubCaracteristique>>.Default.Equals(this.ClubCaracteristiques, club.ClubCaracteristiques) &&
                   EqualityComparer<ICollection<ClubActivite>>.Default.Equals(this.ClubActivites, club.ClubActivites) &&
                   EqualityComparer<ICollection<ClubActiviteEnfant>>.Default.Equals(this.ClubActivitesEnfant, club.ClubActivitesEnfant) &&
                   EqualityComparer<ICollection<Bar>>.Default.Equals(this.Bars, club.Bars) &&
                   EqualityComparer<ICollection<Restaurant>>.Default.Equals(this.Restaurants, club.Restaurants) &&
                   EqualityComparer<ICollection<ClubPaysLocalisation>>.Default.Equals(this.ClubPaysLocalisations, club.ClubPaysLocalisations) &&
                   EqualityComparer<ICollection<ClubTypeClub>>.Default.Equals(this.ClubTypesClub, club.ClubTypesClub) &&
                   EqualityComparer<ICollection<ClubTypeChambre>>.Default.Equals(this.ClubTypesChambre, club.ClubTypesChambre) &&
                   EqualityComparer<ICollection<Reservation>>.Default.Equals(this.Reservations, club.Reservations) &&
                   EqualityComparer<ICollection<Avis>>.Default.Equals(this.Avis, club.Avis);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(this.Id);
            hash.Add(this.IdDomaineSkiable);
            hash.Add(this.Nom);
            hash.Add(this.Description);
            hash.Add(this.LienPDF);
            hash.Add(this.Longitude);
            hash.Add(this.Latitude);
            hash.Add(this.Email);
            hash.Add(this.Domaine);
            hash.Add(this.ClubMultimedias);
            hash.Add(this.ClubTransports);
            hash.Add(this.ClubCaracteristiques);
            hash.Add(this.ClubActivites);
            hash.Add(this.ClubActivitesEnfant);
            hash.Add(this.Bars);
            hash.Add(this.Restaurants);
            hash.Add(this.ClubPaysLocalisations);
            hash.Add(this.ClubTypesClub);
            hash.Add(this.ClubTypesChambre);
            hash.Add(this.Reservations);
            hash.Add(this.Avis);
            return hash.ToHashCode();
        }
    }
}
