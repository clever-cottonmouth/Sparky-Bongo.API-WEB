using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.DataAccess
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTests
    {
        private StudyRoomBooking studyRoomBooking_One;
        private StudyRoomBooking studyRoomBooking_Two;

        public StudyRoomBookingRepositoryTests()
        {
            studyRoomBooking_One = new StudyRoomBooking()
            {
                FirstName = "John",
                LastName = "Smith",
                Date = new DateTime(2023, 1, 1),
                Email = "John@example.com",
                BookingId = 11,
                StudyRoomId = 1
            };
            studyRoomBooking_Two = new StudyRoomBooking()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Date = new DateTime(2023, 2, 2),
                Email = "Jane@example.com",
                BookingId = 12,
                StudyRoomId = 2
            };
        }
        [Test]
        public void SaveBooking_Booking_One_CheckTheValuesFromDatabase()
        {
            //arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_Bango").Options;

            //act
            using (var context = new ApplicationDbContext(options)) 
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking_One);
            }

            //assert
            using(var context = new ApplicationDbContext(options))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(u=>u.BookingId ==11);
                ClassicAssert.AreEqual(studyRoomBooking_One.BookingId, bookingFromDb.BookingId);
                ClassicAssert.AreEqual(studyRoomBooking_One.FirstName, bookingFromDb.FirstName);
                ClassicAssert.AreEqual(studyRoomBooking_One.LastName, bookingFromDb.LastName);
                ClassicAssert.AreEqual(studyRoomBooking_One.Email, bookingFromDb.Email);
                ClassicAssert.AreEqual(studyRoomBooking_One.Date, bookingFromDb.Date);
            }
        }
    }
}