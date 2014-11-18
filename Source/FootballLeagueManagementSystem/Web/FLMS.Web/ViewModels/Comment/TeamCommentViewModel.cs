namespace FLMS.Web.ViewModels.Comment
{
    using AutoMapper;
    using FLMS.Data.Models;
    using FLMS.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class TeamCommentViewModel : IMapFrom<TeamComment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TeamComment, TeamCommentViewModel>()
                         .ForMember(c => c.AuthorName, opt => opt.MapFrom(c => c.Author.UserName));
        }
    }
}