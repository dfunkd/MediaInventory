using System;
using System.Collections.Generic;
using System.Linq;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;

namespace MediaInventory.Data
{
    public partial class Movie
    {
        public Movie(TMDbLib.Objects.Movies.Movie movie)
            : base()
        {
            AlternativeTitles = movie.AlternativeTitles;
            Adult = movie.Adult;
            BackdropPath = movie.BackdropPath;
            BelongsToCollection = movie.BelongsToCollection;
            Budget = movie.Budget;
            Changes = movie.Changes;
            Credits = movie.Credits;
            Genres = movie.Genres;
            Homepage = movie.Homepage;
            Images = movie.Images;
            IMDbId = movie.ImdbId;
            Keywords = movie.Keywords;
            Lists = movie.Lists;
            OriginalTitle = movie.OriginalTitle;
            Overview = movie.Overview;
            Popularity = movie.Popularity;
            PosterPath = movie.PosterPath;
            ProductionCompanies = movie.ProductionCompanies;
            ProductionCountries = movie.ProductionCountries;
            ReleaseDate = movie.ReleaseDate;
            Releases = movie.Releases;
            Revenue = movie.Revenue;
            Runtime = movie.Runtime;
            SpokenLanguages = movie.SpokenLanguages;
            Status = movie.Status;
            Tagline = movie.Tagline;
            Title = movie.Title;
            TMDbId = movie.Id;
            Translations = movie.Translations;
            VoteAverage = movie.VoteAverage;
            VoteCount = movie.VoteCount;

            Name = OriginalTitle;
        }
        public bool IsCheckedOut
        {
            get
            {
                var coh = CheckOutHistories.Where(w => w.MOVid == Id).LastOrDefault();
                if (coh == null)
                    return false;
                return coh.CheckInDate == null;
            }
        }
        public bool Adult { get; set; }
        public AlternativeTitles AlternativeTitles { get; set; }
        public string BackdropPath { get; set; }
        public List<BelongsToCollection> BelongsToCollection { get; set; }
        public long Budget { get; set; }
        public List<Change> Changes { get; set; }
        public Credits Credits { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public Images Images { get; set; }
        public KeywordsContainer Keywords { get; set; }
        public SearchContainer<ListResult> Lists { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public List<ProductionCountry> ProductionCountries { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Releases Releases { get; set; }
        public long Revenue { get; set; }
        public int? Runtime { get; set; }
        public SearchContainer<MovieResult> SimilarMovies { get; set; }
        public List<SpokenLanguage> SpokenLanguages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public TranslationsContainer Translations { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}