using System;
using System.Linq;

namespace MediaInventory.Data
{
    public static class SyncDatabases
    {
        public static void InitializeAzureDatabase()
        {
            using (var localDB = new MediaInventoryEntities())
            {
                //No Constraints
                var localFormats = localDB.Formats.ToList();
                var localQuestions = localDB.SecurityQuestions.ToList();
                var localRoles = localDB.SecurityRoles.ToList();
                var localStates = localDB.States.ToList();
                //Have Constaints
                var localCustomers = localDB.Customers.ToList();
                var localUsers = localDB.InventoryUsers.ToList();
                var localMovies = localDB.Movies.ToList();
                var localHistories = localDB.CheckOutHistories.ToList();
                using (var cloudDB = new MediaInventoryEntities())
                {
                    using (var trans = cloudDB.Database.BeginTransaction())
                    {
                        try
                        {
                            foreach(var format in localFormats)
                                cloudDB.Formats.Add(new Format
                                {
                                    Id = format.Id,
                                    Name = format.Name
                                });
                            foreach(var question in localQuestions)
                            {
                                cloudDB.SecurityQuestions.Add(new Data.SecurityQuestion
                                {
                                    Id = question.Id,
                                    Question = question.Question
                                });
                            }
                            foreach (var role in localRoles)
                                cloudDB.SecurityRoles.Add(new Data.SecurityRole
                                {
                                    Description = role.Description,
                                    Id = role.Id,
                                    Role = role.Role
                                });
                            foreach (var state in localStates)
                                cloudDB.States.Add(new State
                                {
                                    Abbreviation = state.Abbreviation,
                                    Id = state.Id,
                                    Name = state.Name
                                });
                            cloudDB.SaveChanges();
                            foreach (var customer in localCustomers)
                            {
                                var state = cloudDB.States.Where(w => w.Name == customer.State.Name).FirstOrDefault();
                                if (state == null)
                                    continue;
                                cloudDB.Customers.Add(new Customer
                                {
                                    AddressLine1 = customer.AddressLine1,
                                    AddressLine2 = customer.AddressLine2,
                                    CellPhone = customer.CellPhone,
                                    City = customer.City,
                                    EmailAddress = customer.EmailAddress,
                                    FirstName = customer.FirstName,
                                    HomePhone = customer.HomePhone,
                                    Id = customer.Id,
                                    LastName = customer.LastName,
                                    STAid = state.Id,
                                    ZipCode = customer.ZipCode
                                });
                            }
                            cloudDB.SaveChanges();
                            foreach (var user in localUsers)
                            {
                                var role = cloudDB.SecurityRoles.Where(w => w.Role == user.SecurityRole.Role).FirstOrDefault();
                                var sq1 = cloudDB.SecurityQuestions.Where(w => w.Question == user.SecurityQuestion.Question).FirstOrDefault();
                                var sq2 = cloudDB.SecurityQuestions.Where(w => w.Question == user.SecurityQuestion1.Question).FirstOrDefault();
                                var sq3 = cloudDB.SecurityQuestions.Where(w => w.Question == user.SecurityQuestion2.Question).FirstOrDefault();
                                if (role == null || sq1 == null || sq2 == null || sq3 == null)
                                    continue;
                                cloudDB.InventoryUsers.Add(new InventoryUser
                                {
                                    Answer1 = user.Answer1,
                                    Answer2 = user.Answer2,
                                    Answer3 = user.Answer3,
                                    CellPhone = user.CellPhone,
                                    Email = user.Email,
                                    FirstName = user.FirstName,
                                    Id = user.Id,
                                    LastName = user.LastName,
                                    Login = user.Login,
                                    Password = user.Password,
                                    ROLid = role.Id,
                                    SQ1id = sq1.Id,
                                    SQ2id = sq2.Id,
                                    SQ3id = sq3.Id
                                });
                            }
                            cloudDB.SaveChanges();
                            foreach (var movie in localMovies)
                            {
                                var format = cloudDB.Formats.Where(w => w.Name == movie.Format.Name).FirstOrDefault();
                                if (format == null)
                                    continue;
                                cloudDB.Movies.Add(new Movie
                                {
                                    FORId = format.Id,
                                    Id = movie.Id,
                                    IMDbId = movie.IMDbId,
                                    IsOwned = movie.IsOwned,
                                    IsWanted = movie.IsWanted,
                                    Name = movie.Name,
                                    TMDbId = movie.TMDbId
                                });
                            }
                            cloudDB.SaveChanges();
                            foreach (var history in localHistories)
                            {
                                var customer = cloudDB.Customers.Where(w => w.AddressLine1 == history.Customer.AddressLine1 && w.AddressLine2 == history.Customer.AddressLine2 && w.CellPhone == history.Customer.CellPhone && w.City == history.Customer.City
                                    && w.EmailAddress == history.Customer.EmailAddress && w.FirstName == history.Customer.FirstName && w.HomePhone == history.Customer.HomePhone && w.LastName == history.Customer.LastName && w.STAid == history.Customer.State.Id
                                    && w.ZipCode == history.Customer.ZipCode).FirstOrDefault();
                                var movie = cloudDB.Movies.Where(w => w.Name == history.Movie.Name).FirstOrDefault();
                                if (customer == null || movie == null)
                                    continue;
                                cloudDB.CheckOutHistories.Add(new CheckOutHistory
                                {
                                    CheckInDate = history.CheckInDate,
                                    CheckOutDate = history.CheckOutDate,
                                    CSTid = customer.Id,
                                    Id = history.Id,
                                    MOVid = movie.Id
                                });
                            }
                            cloudDB.SaveChanges();
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Synchronize the database on the Azure Server so that is has all the information as the Local Server
        /// </summary>
        public static void SyncCloudToLocal()
        {
            using (var cloudDB = new MediaInventoryEntities())
            {
                using (var localDB = new MediaInventoryEntities())
                {

                }
            }
        }
        /// <summary>
        /// Synchronize the database on the Local Server so that is has all the information as the Azure Server
        /// </summary>
        public static void SyncLocalToCloud()
        {
            using (var localDB = new MediaInventoryEntities())
            {
                using (var cloudDB = new MediaInventoryEntities())
                {

                }
            }
        }
    }
}