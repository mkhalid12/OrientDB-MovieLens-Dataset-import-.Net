using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Orient.Client;

namespace Import_DataSet
{
    public class Occupations:OBaseRecord 
    {
       // public ORID _ORID { get; set; }
        public int OccupationID { get; set; }
        public string Description { get; set; }
        public Occupations()
        {

        }
        public Occupations(int OccID, string Desc)
        {
            OccupationID=OccID;
            Description=Desc;

        }

    }

    
    public class Genres
    {
        public int GenresID{get; set;}
        public string description {get; set;}
        public Genres(int GenID, string desc)
        {
            GenresID = GenID;
            description = desc;
        }
    }
    public class Movies
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string[] Genres { get; set; }
        public Movies()
        {


        }
        public Movies(int mID, string title, string[] genres)
        {
            MovieID = mID;
            Title = title;
            this.Genres = genres;
        }

    }

    public class Users: OVertex
    {
        public int userID { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public int OccupationID { get; set; }
        public string ZipCode { get; set; }

        public Users()
        {

        }
        public Users(int uID, string gender, int age, int OccID, string ZC)
        {
            userID = uID;
            this.gender = gender;
            this.age = age;
            OccupationID = OccID;
            ZipCode = ZC;

        }

    }
    public class Rated
    {
        public int Rating { get; set; }
        public Rated(int Rating)
        {
            this.Rating = Rating;

        }

    }
    public class Rating
    {
        public int userID { get; set; }
        public int movieID { get; set; }
        public int Ratings { get; set; }
        public Rating() { }
        public Rating(int uID, int mID, int Ratngs)
        {
            userID = uID;
            movieID = mID;
            Ratings = Ratngs;

        }

    }

    public class Rating20
    {
        public int userID { get; set; }
        public int movieID { get; set; }
        public int Ratings { get; set; }
        public Rating20() { }
        public Rating20(int uID, int mID, int Ratngs)
        {
            userID = uID;
            movieID = mID;
            Ratings = Ratngs;

        }

    }
  
}
