using Microsoft.Data.SqlClient;
using NEP.Models;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NEP.Data
{
    public class NEPContext : DbContext
    {
        public NEPContext(DbContextOptions<NEPContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Mailer> Mailers { get; set; }
        public DbSet<UserMailerType> UserMailerTypes { get; set; }
        public DbSet<MailerType> MailerTypes { get; set; }
        public DbSet<MailerSignature> MailerSignatures { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Financial> Financials { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<HoursOfPlay> HoursOfPlay{ get; set; }
        public DbSet<HoursOfDelivery> HoursOfDeliveries { get; set; }
        public DbSet<HoursOfFood> HoursOfFood { get; set; }
        public DbSet<HoursOfProShop> HoursOfProShops { get; set; }
        public DbSet<DiningFacility> DiningFacilities { get; set; }
        public DbSet<ProShop> ProShops { get; set; }
        public DbSet<DistanceInMiles> DistancesInMiles { get; set; }
		public DbSet<Court> Courts { get; set; }
		public DbSet<CourtColors> CourtColors { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        public DbSet<CalendarNotification> CalendarNotifications { get; set; }
        public DbSet<Attendee> Attendees { get; set; }


        // Your DbSet properties and other context configurations...

        //      [DbFunction("NEPContext", "DistanceInMiles")]
        //      public virtual DbSet<DistanceInMiles> GetDistanceInMiles(int facilityId,double latitude, double longitude)
        //      {
        //	//throw new NotSupportedException("This method is only used for importing the stored procedure.");
        //	var facId = new SqlParameter("@facilityId", facilityId);
        //	var lat = new SqlParameter("@searchLatitude", latitude);
        //	var lng = new SqlParameter("@searchLongitude", longitude);
        //	var result = DistancesInMiles.FromSqlRaw("EXEC usp_GetFacilitiesWithinRadius @facilityId, @searchLatitude, @searchLongitude", facId, lat, lng).ToList();
        //	return result;
        //}

        public DistanceInMiles GetDistanceInMiles(int facilityId, double latitude, double longitude)
        {
            //throw new NotSupportedException("This method is only used for importing the stored procedure.");
            var facId = new SqlParameter("@facilityId", facilityId);
            var lat = new SqlParameter("@searchLatitude", latitude);
            var lng = new SqlParameter("@searchLongitude", longitude);
			var result = DistancesInMiles.FromSqlRaw("EXEC DistanceInMiles @facilityId, @searchLatitude, @searchLongitude", facId, lat, lng);
			return result.AsEnumerable().FirstOrDefault();
        }

        // Method to call the stored procedure and return the results as a list of Employee objects
        public List<Facility> GetFacilitiesWithinRadius(double latitude, double longitude, double kilometers)
        {
            var lat = new SqlParameter("@centerLat", latitude);
            var lng = new SqlParameter("@centerLon", longitude);
            var rad = new SqlParameter("@radiusInKm", kilometers);
			var result = Facilities.FromSqlRaw("EXEC usp_GetFacilitiesWithinRadius @centerLat,@centerLon,@radiusInKm", lat, lng, rad).ToList();
			return result;
		
		}

        public List<Facility> GetFacilitiesWithinRadiusWithDistance(double latitude, double longitude, double kilometers)
        {
            var lat = new SqlParameter("@searchLatitude", latitude);
            var lng = new SqlParameter("@searchLongitude", longitude);
            var rad = new SqlParameter("@radius", kilometers);
            var result = Facilities.FromSqlRaw("EXEC usp_GetFacilitiesWithinRadiusWithDistance @searchLatitude,@searchLongitude,@radius", lat, lng, rad).ToList();
            return result;
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<Facility>()
                .HasOne(a => a.Address)
                .WithMany(f => f.Facilities)
                .HasForeignKey(a => a.AddressId);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.State)
                .WithMany(f => f.Addresses)
                .HasForeignKey(a => a.StateId);

			modelBuilder.Entity<DistanceInMiles>()
				.HasNoKey();
        }

        
        public DbSet<NEP.Models.CalendarNotification> CalendarNotification { get; set; } = default!;

        
        //public DbSet<NEP.Models.Court> Court { get; set; } = default!;

        
        //public DbSet<NEP.Models.Images> Images { get; set; } = default!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Configure the database connection
        //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("NEP"));

        //}
    }
}

/*
drop table NEP_User
go

create table NEP_SkillLevel(
	Id uniqueidentifier default(newid()) primary key,
	SkillLevel varchar(100) not null,
	[RankSequence] int not null
)

drop table NEP_User
go

create table NEP_User(
	Id uniqueidentifier default(newid()) primary key,
	FirstName varchar(100) not null,
	LastName varchar(100) not null,
	Email varchar(250) not null,
	UserName varchar(100) not null,
	[Password] varchar(max) not null,
	IsActive bit default(1) not null,
	Phone varchar(10) null,
	DateCreated datetime default(getdate()) not null,
	ReferredById uniqueidentifier null,
	FOREIGN KEY (ReferredById) REFERENCES NEP_User(Id),
	IsNewsletter bit default(1) not null,
	IsRegistered bit default(1) not null,
	SkillLevelId uniqueidentifier null,
	FOREIGN KEY (SkillLevelId) REFERENCES NEP_SkillLevel(Id),
	SkillLevelIsVerified bit default(0) not null,
	DOB date null
)
go
select * from NEP_User
insert into NEP_User values(
	'21122112-2112-2112-2112-211221122112'
	,'DEFAULT'
	,'USER'
	,'contact@neverenoughpickleball.com'
	,'DEFAULT_USER'
	,'NOT NEEDED'
	,1
	,'4075474111'
	,getdate()
	,null
	,1
	,1
	,null
	,0
	,'1/1/2000'
)

select * from NEP_User

create table NEP_Country(
	Id uniqueidentifier default(newid()) primary key,
	[Name] varchar(200) not null,
	Alpha_2 varchar(10) not null,
	Alpha_3 varchar(10) not null,
	[Numeric] int not null,
	ISO_3166_2 varchar(20) not null
)

create table NEP_StateProvince(
	Id uniqueidentifier default(newid()) primary key,
	[Name] varchar(200) not null,
	Abbreviation varchar(10) not null
)

create table NEP_Address(
	Id uniqueidentifier default(newid()) primary key,
	Address1 varchar(100) not null,
	Address2 varchar(100) null,
	City varchar(100) not null,
	StateProvinceId uniqueidentifier not null,
	FOREIGN KEY (StateProvinceId) REFERENCES NEP_StateProvince(Id),
	CountryId uniqueidentifier not null,
	FOREIGN KEY (CountryId) REFERENCES NEP_Country(Id)
)


create table NEP_Tender(
	Id uniqueidentifier default(newid()) primary key,
	TenderType varchar(100) not null
)

insert into NEP_Tender values ('Cash')
insert into NEP_Tender values ('CC - Visa')
insert into NEP_Tender values ('CC - Mastercard')
insert into NEP_Tender values ('CC - Amex')
insert into NEP_Tender values ('CC - Discover')
insert into NEP_Tender values ('CashApp')
insert into NEP_Tender values ('Venmo')
insert into NEP_Tender values ('Zelle')
insert into NEP_Tender values ('Paypal')
insert into NEP_Tender values ('Text')
insert into NEP_Tender values ('Zeffy')


create table NEP_Donation(
	Id uniqueidentifier default(newid()) primary key,
	IsAnonymous bit default(0) not null,
	NEP_UserId uniqueidentifier null,
	FOREIGN KEY (NEP_UserId) REFERENCES NEP_User(Id),
	Amount decimal(18,2) not null,
	DateCreated datetime default(getdate()) not null,
	TenderId uniqueidentifier not null,
	FOREIGN KEY (TenderId) REFERENCES NEP_Tender(Id),
	TransactionId varchar(1000) null,
	LastFourOfCard char(4) null,
	ReceiptRequired bit default(0) not null,
	ReceiptIssued bit default(0) not null
)
*/
