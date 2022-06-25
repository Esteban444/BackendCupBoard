using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductManagment.Dto.Models;

namespace ProductManagment.Infrastructure.Data
{
    public class CupBoardContext: IdentityUserContext<ApplicationUser>
    {
        public CupBoardContext(DbContextOptions<CupBoardContext> options) 
            : base(options)
        {
        }

        public DbSet<CategoryXProducts>? CategoriesXproduct { get; set; }
        public DbSet<Categories>? Categories { get; set; }
        public DbSet<CupBoards>? CupBoards { get; set; }
        public DbSet<CupBoardDetails>? CupBoardDetail { get; set; }
        public DbSet<Products>? Products { get; set; }
        public DbSet<ShoppingLists>? ShoppingList { get; set; }
        public DbSet<TradeMarks>? Trademarks { get; set; }  
        public DbSet<ApplicationUser>? User { get; set; }
        public DbSet<UserXCupBoards>? UserXcupBoard { get; set; }
        public DbSet<UsersXShoppingLists>? UserXshoppingLists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CategoryXProducts>(entity =>
            {
                entity.HasKey(e => e.IdCategoryXproduct)
                    .HasName("PK__Categori__E775EBF5BECA41C4");

                entity.Property(e => e.IdCategoryXproduct).IsUnicode(false);

                entity.Property(e => e.IdCategory).IsUnicode(false);

                entity.Property(e => e.IdProduct).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoriesXproducts)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK_Category_CategoryXProduct");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CategoriesXproducts)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Product_CategoryXProduct");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.IdCategory).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<CupBoards>(entity =>
            {
                entity.HasKey(e => e.IdCupBoard)
                    .HasName("PK__CupBoard__089DCDC596B81653");

                entity.Property(e => e.IdCupBoard);

                entity.Property(e => e.NameCupBoard);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CupBoardDetails>(entity =>
            {
                entity.ToTable("CupBoardDetail");

                entity.HasKey(e => e.IdCupboardDetail)
                    .HasName("PK__CupBoard__45BC4B6ADE04BAA2");

                entity.Property(e => e.IdCupboardDetail).HasColumnName("idCupboardDetail");

                entity.Property(e => e.IdCupBoard).HasColumnName("idCupBoard");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.ExitDate).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.HasOne(d => d.CupBoard)
                    .WithMany(p => p.CupBoardDetails)
                    .HasForeignKey(d => d.IdCupBoard)
                    .HasConstraintName("FK_CupBoard_Detail");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CupBoardDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_CupBoard_Products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Products__5EEC79D120FD1CAC");

                entity.Property(e => e.IdProduct).IsUnicode(false);

                entity.Property(e => e.IdMark).IsUnicode(false);

                entity.Property(e => e.NameProduct).IsUnicode(false);

                entity.Property(e => e.BarCode).IsUnicode(false);

                entity.HasOne(d => d.Trademark)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdMark)
                .HasConstraintName("FK_Mark_Products")
                ;
            });

            modelBuilder.Entity<ShoppingLists>(entity =>
            {
                entity.HasKey(e => e.IdShopping)
                    .HasName("PK__Shopping__957AB8FE0BB0BFD7");

                entity.Property(e => e.IdShopping).IsUnicode(false);

                entity.Property(e => e.IdProduct).IsUnicode(false);

                entity.Property(e => e.Value).HasColumnName("value_");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingLists)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_User_Shopping");
            });

            modelBuilder.Entity<TradeMarks>(entity =>
            {
                entity.HasKey(e => e.IdTrademark)
                    .HasName("PK__Trademar__7C4427A36D95025C");

                entity.Property(e => e.IdTrademark).IsUnicode(false);

                entity.Property(e => e.Mark).IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Users__3717C982E1EBA768");

                entity.Property(e => e.Id).IsUnicode(false);
            });

            modelBuilder.Entity<UserXCupBoards>(entity =>
            {
                entity.HasKey(e => e.IdUserXCupBoard)
                    .HasName("PK__UserXCup__D653D90B6AEE5AA5");

                entity.Property(e => e.IdUserXCupBoard).HasColumnName("idUserXCupBoard");

                entity.Property(e => e.IdCupBoard).IsUnicode(false);

                entity.Property(e => e.IdUser).IsUnicode(false);

                entity.HasOne(d => d.CupBoard)
                    .WithMany(p => p.UserXcupBoards)
                    .HasForeignKey(d => d.IdCupBoard)
                    .HasConstraintName("FK_CupBoard_UserCupBoard");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserXcupBoards)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_User_CupBoard");
            });

            modelBuilder.Entity<UsersXShoppingLists>(entity =>
            {
                entity.HasKey(e => e.IdUserXshopping)
                    .HasName("PK__UserXSho__3DDAB8017C0E8680");

                entity.Property(e => e.IdUserXshopping).HasColumnName("idUserXShoppingList");

                entity.Property(e => e.IdShopping).IsUnicode(false);

                entity.Property(e => e.IdUser).IsUnicode(false);

                entity.HasOne(d => d.Shopping)
                    .WithMany(p => p.UserXshoppingLists)
                    .HasForeignKey(d => d.IdShopping)
                    .HasConstraintName("FK_Shopping_UserXShopping");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserXshoppingLists)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_User_UserXShopping");
            });

            modelBuilder.Entity<CategoryXProducts>().Property(e => e.IdCategoryXproduct).HasConversion<string>();
            modelBuilder.Entity<Categories>().Property(e => e.IdCategory).HasConversion<string>();
            modelBuilder.Entity<CupBoards>().Property(e => e.IdCupBoard).HasConversion<string>();
            modelBuilder.Entity<CupBoardDetails>().Property(e => e.IdCupboardDetail).HasConversion<string>();
            modelBuilder.Entity<Products>().Property(e => e.IdProduct).HasConversion<string>();

            modelBuilder.Entity<ShoppingLists>().Property(e => e.IdShopping).HasConversion<string>();
            modelBuilder.Entity<ShoppingLists>().Property(e => e.IdProduct).HasConversion<string>();

            modelBuilder.Entity<TradeMarks>().Property(e => e.IdTrademark).HasConversion<string>();

            modelBuilder.Entity<ApplicationUser>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<UserXCupBoards>().Property(e => e.IdUserXCupBoard).HasConversion<string>();
            modelBuilder.Entity<UsersXShoppingLists>().Property(e => e.IdUserXshopping).HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
