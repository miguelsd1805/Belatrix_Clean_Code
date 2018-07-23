using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;
using CleanCode.FullRefactoring;

namespace Project.UserControls
{
    public class PostControl : System.Web.UI.UserControl
    {
        private readonly PostRepository _repository;
        public PostControl (PostDbContext context)
	    {
            this._repository = new PostRepository(context);
	    }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                TrySavePost();
            else
                SetFormFromPostId();
        }

        private void TrySavePost(){
            Post entity = CreatePostFromForm();
            var validationResult = ValidatePost();
            if (validationResult.IsValid)
                _repository.SavePost(entity);
            else
                DisplayErrors(validationResult.Errors);
        }

        private ValidationResult ValidatePost(Post entity)
        {
            PostValidator validator = new PostValidator();
            return validator.Validate(entity);
        }

        private Post CreatePostFromForm(){
            return new Post()
            {
                // Map form fields to entity properties
                Id = Convert.ToInt32(PostId.Value),
                Title = PostTitle.Text.Trim(),
                Body = PostBody.Text.Trim()
            };
        }

        private void SetFormFromPostId(){
            Post entity = _repository.GetPost(Convert.ToInt32(Request.QueryString["id"]));
            PostBody.Text = entity.Body;
            PostTitle.Text = entity.Title;
        }

        private void DisplayErrors(IEnumerable<ValidationError> errorList){
            BulletedList summary = (BulletedList)FindControl("ErrorSummary");

            // Display errors to the user
            foreach (var failure in errorList)
            {
                Label errorMessage = FindControl(failure.PropertyName + "Error") as Label;

                if (errorMessage == null)
                {
                    summary.Items.Add(new ListItem(failure.ErrorMessage));
                }
                else
                {
                    errorMessage.Text = failure.ErrorMessage;
                }
            }
        }

        public Label PostBody { get; set; }

        public Label PostTitle { get; set; }

        public int? PostId { get; set; }

    }

    #region helpers

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
    }

    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class PostValidator
    {
        public ValidationResult Validate(Post entity)
        {
            throw new NotImplementedException();
        }
    }

    public class DbSet<T> : IQueryable<T>
    {
        public void Add(T entity)
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get { throw new NotImplementedException(); }
        }

        public Type ElementType
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryProvider Provider
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class PostDbContext
    {
        public DbSet<Post> Posts { get; set; }

        public void SaveChanges()
        {
        }
    }
    #endregion

}