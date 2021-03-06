﻿namespace FLMS.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using FLMS.Data;
    using FLMS.Data.Models;
    using FLMS.Web.ViewModels.Comment;
    using Microsoft.AspNet.Identity;

    public class CommentsController : BaseController
    {
        public CommentsController(IFlmsData data) : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostTeamComment(PostTeamCommentViewModel comment)
        {
            if (comment != null && ModelState.IsValid)
            {
                var dbComment = Mapper.Map<TeamComment>(comment);
                dbComment.AuthorId = User.Identity.GetUserId();

                var team = this.Data.Teams.GetById(comment.TeamId);
                if (team == null)
                {
                    throw new HttpException(404, "Team not found");
                }

                team.Comments.Add(dbComment);
                this.Data.SaveChanges();

                var viewModel = Mapper.Map<TeamCommentViewModel>(dbComment);

                return this.PartialView("_TeamCommentPartial", viewModel);
            }

            throw new HttpException(400, "Invalid comment");
        }
    }
}