using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Quiz_App.DataModels;
using Quiz_App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz_App.Activities
{
    [Activity(Label = "QuizActivity")]
    public class QuizActivity : AppCompatActivity
    {
        AndroidX.AppCompat.Widget.Toolbar toolbar;

        //Radio Buttons
        RadioButton optionARadio, optionBRadio, optionCRadio, optionDRadio;

        //Text views
        TextView optionATextView, optionBTextView, optionCTextView, optionDTextView, timeCounterTextView, quizPositionTextView, questionTextView;

        //Button
        Button acceptAnswerButton;

        //Var
        List<Question> quizQuestionList = new List<Question>();
        QuizHelper quizHelper = new QuizHelper();

        string quizTopic;
        int quizPosition;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.quiz_page);

            quizTopic = Intent.GetStringExtra("topic");


            //Setting a toolbar
            toolbar = (AndroidX.AppCompat.Widget.Toolbar)FindViewById(Resource.Id.quizToolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = quizTopic + " Quiz";
            AndroidX.AppCompat.App.ActionBar actionBar = SupportActionBar;
            actionBar.SetHomeAsUpIndicator(Resource.Drawable.outline_arrowback);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            ConnectViews();
            BeginQuiz();
        }

        void ConnectViews()
        {
            //Radio Buttons
            optionARadio = (RadioButton)FindViewById(Resource.Id.optionARadio);
            optionBRadio = (RadioButton)FindViewById(Resource.Id.optionBRadio);
            optionCRadio = (RadioButton)FindViewById(Resource.Id.optionCRadio);
            optionDRadio = (RadioButton)FindViewById(Resource.Id.optionDRadio);

            optionARadio.Click += OptionARadio_Click;
            optionBRadio.Click += OptionBRadio_Click;
            optionCRadio.Click += OptionCRadio_Click;
            optionDRadio.Click += OptionDRadio_Click;
            //TextViews
            optionATextView = (TextView)FindViewById(Resource.Id.optionATextView);
            optionBTextView = (TextView)FindViewById(Resource.Id.optionBTextView);
            optionCTextView = (TextView)FindViewById(Resource.Id.optionCTextView);
            optionDTextView = (TextView)FindViewById(Resource.Id.optionDTextView);

            optionATextView.Click += OptionATextView_Click;
            optionBTextView.Click += OptionBTextView_Click;
            optionCTextView.Click += OptionCTextView_Click;
            optionDTextView.Click += OptionDTextView_Click;

            timeCounterTextView = (TextView)FindViewById(Resource.Id.timeCounterTextView);
            quizPositionTextView = (TextView)FindViewById(Resource.Id.quizPositionTextView);
            questionTextView = (TextView)FindViewById(Resource.Id.questionTextView);
            //Button
            acceptAnswerButton = (Button)FindViewById(Resource.Id.acceptAnswerButton);

            acceptAnswerButton.Click += AcceptAnswerButton_Click;
        }

        //Accepting answer button click event handler
        private void AcceptAnswerButton_Click(object sender, EventArgs e)
        {
            if (optionARadio.Checked)
            {
                if (optionATextView.Text == quizQuestionList[quizPosition - 1].Answer)
                {
                    Toast.MakeText(this, "You got it!", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "It is a wrong answer :(", ToastLength.Short).Show();
                }
            }
            else if (optionBRadio.Checked) 
            {
                if (optionBTextView.Text == quizQuestionList[quizPosition - 1].Answer)
                {
                    Toast.MakeText(this, "You got it!", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "It is a wrong answer :(", ToastLength.Short).Show();
                }
            }
            else if (optionCRadio.Checked) 
            {
                if (optionCTextView.Text == quizQuestionList[quizPosition - 1].Answer)
                {
                    Toast.MakeText(this, "You got it!", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "It is a wrong answer :(", ToastLength.Short).Show();
                }
            }
            else if (optionDRadio.Checked) 
            {
                if (optionDTextView.Text == quizQuestionList[quizPosition - 1].Answer)
                {
                    Toast.MakeText(this, "You got it!", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "It is a wrong answer :(", ToastLength.Short).Show();
                }
            }
            else Toast.MakeText(this, "Please choose your answer!", ToastLength.Short).Show(); //No option selected
        }

        //Answers text views click event handlers
        private void OptionDTextView_Click(object sender, EventArgs e)
        {
            OptionDRadio_Click(sender, e);
        }

        private void OptionCTextView_Click(object sender, EventArgs e)
        {
            OptionCRadio_Click(sender, e);
        }

        private void OptionBTextView_Click(object sender, EventArgs e)
        {
            OptionBRadio_Click(sender, e);
        }

        private void OptionATextView_Click(object sender, EventArgs e)
        {
            OptionARadio_Click(sender, e);
        }

        //Radio Click Event Handlers
        private void OptionDRadio_Click(object sender, EventArgs e)
        {
            ClearOptionSelected();
            optionDRadio.Checked = true;
        }

        private void OptionCRadio_Click(object sender, EventArgs e)
        {
            ClearOptionSelected();
            optionCRadio.Checked = true;
        }

        private void OptionBRadio_Click(object sender, EventArgs e)
        {
            ClearOptionSelected();
            optionBRadio.Checked = true;
        }

        private void OptionARadio_Click(object sender, EventArgs e)
        {
            ClearOptionSelected();
            optionARadio.Checked = true;
        }

        //Method which clears other options
        void ClearOptionSelected()
        {
            optionARadio.Checked = false;
            optionBRadio.Checked = false;
            optionCRadio.Checked = false;
            optionDRadio.Checked = false;
        }
        void BeginQuiz()
        {
            quizPosition = 1;
            quizQuestionList = quizHelper.GetQuizQuestions(quizTopic);
            questionTextView.Text = quizQuestionList[0].QuizQuestion;
            optionATextView.Text = quizQuestionList[0].OptionA;
            optionBTextView.Text = quizQuestionList[0].OptionB;
            optionCTextView.Text = quizQuestionList[0].OptionC;
            optionDTextView.Text = quizQuestionList[0].OptionD;

            quizPositionTextView.Text = "Question " + quizPosition.ToString() + "/" + quizQuestionList.Count();
        }
    }
}