using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orient.Client;
using System.IO;


namespace Import_DataSet
{
    class Program
    {
        static string _PathUsers = @"E:\Semester 1\ADB\Orient DB\ml-20m\users.dat";
        static string _PathMovies = @"E:\Semester 1\ADB\Orient DB\ml-20m\movies.dat";
        static string _PathRatings = @"E:\Semester 1\ADB\Orient DB\ml-20m\ratings.dat";
        //static string _PathRatings20M = @"E:\Semester 1\ADB\Orient DB\ml-20m\ratings_20M.csv";
      
        
      
        static List<Occupations> LoadOccupations()
        {
            List<Occupations> _list = new List<Occupations>();

            _list.Add(new Occupations(0, "other or not specified"));
            _list.Add(new Occupations(1, "academic/educator"));
            _list.Add(new Occupations(2, "artist"));
            _list.Add(new Occupations(3, "clerical/admin"));
            _list.Add(new Occupations(4, "college/grad student"));
            _list.Add(new Occupations(5, "customer service"));
            _list.Add(new Occupations(6, "doctor/health care"));
            _list.Add(new Occupations(7, "executive/managerial"));
            _list.Add(new Occupations(8, "farmer"));
            _list.Add(new Occupations(9, "homemaker"));
            _list.Add(new Occupations(10, "K-12 student"));
            _list.Add(new Occupations(11, "lawyer"));
            _list.Add(new Occupations(12, "programmer"));
            _list.Add(new Occupations(13, "retired"));
            _list.Add(new Occupations(14, "sales/marketing"));
            _list.Add(new Occupations(15, "scientist"));
            _list.Add(new Occupations(16, "self-employed"));
            _list.Add(new Occupations(17, "technician/engineer"));
            _list.Add(new Occupations(18, "tradesman/craftsman"));
            _list.Add(new Occupations(19, "unemployed"));
            _list.Add(new Occupations(20, "writer"));

            return _list;
        }

        static List<Genres> LoadGenres()
        {
            List<Genres> _list = new List<Genres>();
             _list.Add(new Genres(1,"Action"));
            _list.Add(new Genres(2,"Adventure"));
            _list.Add(new Genres(3,"Animation"));
            _list.Add(new Genres(4,"Children's"));
            _list.Add(new Genres(5,"Comedy"));
            _list.Add(new Genres(6,"Crime"));
            _list.Add(new Genres(7,"Documentary"));
            _list.Add(new Genres(8,"Drama"));
            _list.Add(new Genres(9,"Fantasy"));
            _list.Add(new Genres(10,"Film-Noir"));
            _list.Add(new Genres(11,"Horror"));
            _list.Add(new Genres(12,"Musical"));
            _list.Add(new Genres(13,"Mystery"));
            _list.Add(new Genres(14,"Romance"));
            _list.Add(new Genres(15,"Sci-Fi"));
            _list.Add(new Genres(16,"Thriller"));
            _list.Add(new Genres(17,"War"));
            _list.Add(new Genres(18,"Western"));


            return _list;
        }
        static List<Users> LoadUsers()
        {
          
            List<Users> _listUsers = new List<Users>();

            using (StreamReader sr = new StreamReader(_PathUsers))
            {
                try
                {
                    // Read the stream to a string, and write the string to the console.
                    String allData = sr.ReadToEnd();
                    string[] splitRows = allData.Split('\n');
                    foreach (string record in splitRows)
                    {
                        string[] splitAttribute = record.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                        if (splitAttribute.Length > 0)
                        {
                            int userID = int.Parse(splitAttribute[0]);
                            string gender = (splitAttribute[1]);
                            int age = int.Parse(splitAttribute[2]);
                            int OccupationID = int.Parse(splitAttribute[3]);
                            string ZipCode = (splitAttribute[4]);
                            _listUsers.Add(new Users(userID, gender, age, OccupationID, ZipCode));
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return _listUsers;

        }

        static List<Movies> LoadMovies()
        {
            List<Movies> _listMovies = new List<Movies>();
            using (StreamReader sr = new StreamReader(_PathMovies))
            {
                try
                {
                    // Read the stream to a string, and write the string to the console.
                    String allData = sr.ReadToEnd();
                    string[] splitRows = allData.Split('\n');
                    foreach (string record in splitRows)
                    {
                        string[] splitAttribute = record.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                        if (splitAttribute.Length > 0)
                        {
                            int movieID = int.Parse(splitAttribute[0]);
                            string Title = (splitAttribute[1]);
                            string[] genres=splitAttribute[2].Split('|');

                            _listMovies.Add(new Movies(movieID, Title, genres));
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return _listMovies;

        }
        static List<Rating> LoadRatings(string Path)
        {
            List<Rating> _listRatings = new List<Rating>();
            using (StreamReader sr = new StreamReader(Path))
            {
                try
                {
                    // Read the stream to a string, and write the string to the console.
                    String allData = sr.ReadToEnd();
                    string[] splitRows = allData.Split('\n');
                    foreach (string record in splitRows)
                    {
                        string[] splitAttribute = record.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                        if (splitAttribute.Length > 0)
                        {
                            int userID = int.Parse(splitAttribute[0]);
                            int movieID =int.Parse (splitAttribute[1]);
                            int rating = int.Parse(splitAttribute[2]);
                            _listRatings.Add(new Rating(userID, movieID, rating));
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return _listRatings;

        }

        static List<Rating> LoadRatings20(string Path)
        {
            List<Rating> _listRatings = new List<Rating>();
            using (StreamReader sr = new StreamReader(Path))
            {
                try
                {
                    // Read the stream to a string, and write the string to the console.
                    String allData = sr.ReadToEnd();
                    string[] splitRows = allData.Split('\n');
                    foreach (string record in splitRows)
                    {
                        string[] splitAttribute = record.Split(',');
                        if (splitAttribute.Length > 0)
                        {
                            int userID = int.Parse(splitAttribute[0]);
                            int movieID = int.Parse(splitAttribute[1]);
                            int rating = int.Parse(splitAttribute[2]);
                            _listRatings.Add(new Rating(userID, movieID, rating));
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return _listRatings;

        }

        static void Main(string[] args)
        {

        

            List<Occupations> _lisOccupations = LoadOccupations();

            #region

            try
            {
              

                OrientDBDriver.CreateDatabase();
                OrientDBDriver.CreatePool();

                ODatabase oDB = new ODatabase(OrientDBDriver.DatabaseAlias);
           
                // we are setting Database to useLightweightEdges set to True because currently 
                // we don't need any properties in edges for User hasOccupationa and Movies_genres
                oDB.Command("ALTER DATABASE custom useLightweightEdges=true");

                #region Load Occupation
                // First of all create Class of Occupation  which extends from vertex class V
                Console.WriteLine("Creating VERTEX Occupation ....");
         
                oDB.Create.Class<Occupations>().Extends<OVertex>().CreateProperties<Occupations>().Run();
                foreach (Occupations occ in _lisOccupations)
                {
                    
                    oDB.Create.Vertex<Occupations>(occ).Run();

                }
                Console.WriteLine("Successfully created Vertex Occupation");
                #endregion

                #region Load Users

                List<Users> _listUsers = LoadUsers();
                Console.WriteLine("Creating VERTEX Users with relation 'hasOccupation' using EDGE ....");
                    
                oDB.Create.Class<Users>().Extends<OVertex>().CreateProperties().Run();
                oDB.Create.Class("hasOccupation").Extends<OEdge>().Run();
                
                foreach (Users user in _listUsers)
                {
                    ODocument odoc = oDB.Create.Vertex("Users")
                                   .Set("userID", user.userID)
                                   .Set("Gender", user.gender)
                                  // .Set("OccupationID",user.OccupationID)
                                   .Set("Age", user.age)
                                   .Set("ZipCode", user.ZipCode)
                                   .Run();

                    string generateSQL = new OSqlSelect().Select().From("Occupations").Where("OccupationID").Equals(user.OccupationID).Limit(1).ToString();
                    List<ODocument> result = oDB.Query(generateSQL);
                    if (result.Count > 0)
                    {
                        OEdge edge = oDB.Create.Edge("hasOccupation").From(odoc.ORID).To(result[0].ORID).Run();
                    }
                }

                Console.WriteLine("Successfully created Vertex Users");
                #endregion

                #region Load Genres
                List<Genres> _listGenres = LoadGenres();

                Console.WriteLine("Creating VERTEX Genres ....");
                oDB.Create.Class<Genres>().Extends<OVertex>().CreateProperties<Genres>().Run();

                foreach (Genres g in _listGenres)
                {
                    oDB.Create.Vertex<Genres>(g).Run();

                }
                Console.WriteLine("Successfully created Vertex Occupation");

                Console.WriteLine("Successfully created Vertex Genres");
                #endregion

                #region Load Movies
                // ------------- Load Movies with Relation Genres-----------------
                List<Movies> _listMovies = LoadMovies();

                Console.WriteLine("Creating VERTEX Movies ....");
                oDB.Create.Class<Movies>().Extends<OVertex>().CreateProperties().Run();
                oDB.Create.Class("hasGenera").Extends<OEdge>().Run();
                foreach (Movies g in _listMovies)
                {
                    ODocument odoc = oDB.Create.Vertex("Movies")
                                   .Set("MovieID", g.MovieID)
                                   .Set("Title", g.Title)
                                   .Run();

                    foreach (string genres in g.Genres)
                    {
                        string generateSQL = new OSqlSelect().Select().From("Genres").Where("description").Equals(genres).Limit(1).ToString();
                        List<ODocument> result = oDB.Query(generateSQL);
                        if (result.Count > 0)
                        {
                            OEdge edge = oDB.Create.Edge("hasGenera").From(odoc.ORID).To(result[0].ORID).Run();
                        }
                    }

                }

                Console.WriteLine("Successfully created Vertex Movies with relation has genres");
                #endregion

                //---------- Load One Million I takes almost ~20mins in Core i7 6th Gen, 2.5 GHz processor with 8GB RAM
                // --- Waiting for response from OrientDB for Bulkinsert (massiveinsert) operaion support in .Net API

                #region Load Ratings

                oDB.Command("ALTER DATABASE custom useLightweightEdges=false");
                oDB.Create.Class<Rated>().Extends<OEdge>().CreateProperties().Run();

                oDB.Command("CREATE INDEX users.userID UNIQUE");
                oDB.Command("CREATE INDEX Movies.movieID UNIQUE");

                Console.WriteLine("Creating Ratings one Million....");
                int i = 0;
                System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
                st.Start();
                
                List<Rating> _listRating = LoadRatings(_PathRatings);
                oDB.Transaction.Reset();
                
                object locker = new object();
                Parallel.ForEach(_listRating, r=>
                {
                    lock (locker)
                    {
                        i++;
                        // we can also use OrientDB command to create Edges between two vertices
                        oDB.Command(" create edge rated from (select from Users where userID = " + r.userID + ") to (select from Movies where MovieID = " + r.movieID + "  ) set rating =" + r.Ratings + "  ");
                        Console.WriteLine("Creating Ratings...." + i.ToString());

                    }
                   
                });
                st.Stop();
                Console.WriteLine("Successfully Created Ratings Transaction committed...." + st.Elapsed.TotalMinutes + "mins");
                #endregion

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

                #endregion

                Console.ReadLine();


        }
        }

    }
