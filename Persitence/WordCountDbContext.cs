﻿using System;
using Domain_models.Entities;
using KnowledgeExtraction.Common;
using Microsoft.EntityFrameworkCore;

namespace DataAndInfrastructure
{
    internal class WordCountContext : DbContext, IWordRatioContext, IWordCountContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<OccursIn> WordOccurances { get; set; }
        public DbSet<WordRatio> Ratios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Keys
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Article>().HasKey(a => a.Id);
            modelBuilder.Entity<Word>().HasKey(a => a.Literal);
            modelBuilder.Entity<OccursIn>().HasKey(w => new {w.ArticleId, w.Word});
            
            //Navigation properties
            modelBuilder.Entity<OccursIn>().HasOne(w => w.Article).WithMany(a => a.WordOccurances)
                .HasForeignKey(w => w.ArticleId);
            modelBuilder.Entity<Article>().HasOne(article => article.Author).WithMany(author => author.WrittenArticles).HasForeignKey(a => a.AuthorId);
        }

    }


}