using OOPsReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPvReview
{
    public class Employment
    {
        //data members
        //aka fields, variables, attributes
        //typically data members are private and hold data for use
        //  within your class
        //usually associated with a property
        //a data member does not have any built-in validation
        private string _Title;
        private double _Years;

        //properties
        //are associated with a single piece of data.
        //Properties can be implemented by:
        //  a) fully implemented property
        //  b) auto implemented property

        //A property does not need to store data
        //  this type of property is referred to as a read-only
        //  this property typically uses existing data values
        //      within the instance to return a computed value 
        // NOTE there would be NO set for the property

        //Assume two data fields _FirstName and _LastName
        //public string FullName
        //{
        //    get { return _FastName + " " + _LastName; }
        //}

        //fully implemented property
        //fully implemented properties usually has additional logic
        //  to execute for control over the data: such as validation
        //fully implemented properties will have a declared data
        //  member to store the data into

        ///<summary>
        ///Property: Title
        ///datatype: string
        ///validation: there must be a character in the string
        ///a property will always have a getter (accessor)
        ///a property may or maynot have a setter (mutator)
        /// no mutator the property is consider "read-only" and is
        ///         usually returning a computed field
        /// has a mutator, the property will at some point save the data
        ///     to storage
        /// the mutator may be public (default) or private
        ///     public: accessible by outside users of the class
        ///     private: accessible ONLY within the class, usually
        ///                 via the constructor or a method
        /// !!!!! a property DOES NOT have ANY declared incoming parameters !!!!!!
        /// </summary>
        /// 


        //string mytitle = myinstance.Title;

        public string Title
        {
            get
            {
                //accessor (getter)
                //returns the string associated with this property
                return _Title;
            }
            set
            {
                //mutator (setter)
                //it is within the set that the validation of the data
                //  is done to determine if the data is acceptable
                //if all processing of the string is done via the property
                //  it will ensure that good data is within the associated string
                if (string.IsNullOrWhiteSpace(value))
                {
                    //classes typically do not write to the console.
                    //classes will throw Exceptions that must be handled in a 
                    //  user friendly fashion by the outside user
                    throw new ArgumentNullException("Title", "Title may not be empty or blank.");
                }
                else
                {
                    //it is a very good practice to remove leading and trailing spaces on strings
                    //  so that only the required and important characters are stored.
                    //to do this sanitization use .Trim()
                    _Title = value.Trim();
                }
            }
        }
        public double Years // fullt implemented property
        {
            get
            {
                return _Years;
            }

            //get => _Years; another way to write a get

            set
            {
                if (double.IsNegative(value)) //thas interesting built in function
                {
                    throw new ArgumentException($"Years value {value} must be 0 or greater.");
                    //
                }
                // the else is not required since the throw will exit the method
                _Years = value;
                //if (value >= 0)
                //_Years = value;
                //else throw new ArgumentException("Years must be 0 or greater.");
            }
        }

        ///<summary>
        ///Property: Years
        ///validation: the value must be 0 or greater
        ///datatype: double
        ///</summary>
        ///

        ///<summary>
        ///Property: StartDate
        ///validation: none
        ///set access: private
        ///datatype: DateTime
        ///</summary>
        ///
        /// 
        /////since the access to this property for the mutator is private ANY validation
        //  for this data will need to be done elsewhere
        //possible locations for the validation could be in
        //  a) a constructor
        //  b) any method that will alter the data
        //a private mutator will NOT allow alteration of the data via a property for the
        //  outside user, however, methods within the class will still be able to
        //  use the property

        //auto implemented properties do not have additional logic
        //Auto implemented properties do not have a declared
        //  data member instead the o/s will create on the property's
        //  behalf a storage that is accessible ONLY by the property

        //!!!NOTE: this property is ONLY demonstrating the possibility of using 
        //         a private access on the set.
        //         The private access has NO relationship to the fact that the property
        //         is an auto implemented property

        public DateTime StartDate { get; private set; }

        ///<summary>
        ///Property: Level
        ///validation: none
        ///datatype: this is an enum (SupervisoryLevel)
        ///</summary>
        ///

        public SupervisoryLevel Level { get; set; }

        //can an auto-implemented property be coded as a fully-implemented property?
        //YES

        //private SupervisoryLevel _Level;  //data member
        //public SupervisoryLevel Level     //property
        //{
        //   get {return _Level;}
        //   set (_Level = value;}
        //}

        //constructors // must be the class name


        //your class does not technically need a coded constructor
        //if you code a constructor for your class you are responsible for coding ALL constructors
        //if you do not code a constructor then the system will assign the software datatype defaults
        //  to your variables (data members/auto-implemented properties)

        //if Employment did not have any code constructor the following is the class initation
        //  _Title = null
        //  _Years = 0.0
        //  StartDate = 01/01/0001
        //  Level = SupervisoryLevel.Entry (int defaults to 0)

        //syntax: accesslevel constructorname([list of parameters]) { .... }
        //NOTE: NO return datatype you calling indirectly the class name
        //      the constructorname MUST be the class name

        //if there is no code within this constructor, the actions for setting
        //  your internal fields will be using the system defaults for the datatype

        //Default constructor  simulates the "system defaults"
        public Employment() //default constructor
        { //optionally
        // you could assign values to your initial fields within this constructor typically
        //      using literal values
        //Why?
        // your internal fields may have validation attached to the data for the field
        // this validation is usually within the property
        //
        // you would wish to have valid data values for your internal fields
        // you may wish to have a reason value that differs from the default datatype value
        // you may wish to have some other value than the default
            Title = "Unknown"; //This cannot be null, empty or blank; cannot use the system default
            StartDate = DateTime.Today; // a dat of 01/01/00001 is not reasonable for this application
            Level = SupervisoryLevel.TeamMember; // most of my people are team members
            //Years??
            // the default is fine (0.0)
            //does one have to assign a value: NO
            //COULD ONE ASSIGN A VALUE: yes
            //IF YOU WISH you could acctually assign the value 0 yourself.
            Years = 0.0;


        }
        //Greedy

        //this is the constructor typically used to assign values to a instance at the time of

        //    creation

        //the list of parameters may or may not contain default parameter values

        //if you have assigned default parameter values then those parameters MUST be at the end of

        //  the parameter list

        //in this example years is a default parameter (it has an assigned value if the value

        //  is not included on the coded constructor in the user program

        //using a call to a method with default parameter

        //     Employment myJob = new Employment("PGI", SupervisoryLevel.Entry,

        //                                          DateTime.Today);


        public Employment(string title, SupervisoryLevel level, DateTime startdate, double years = 0.0)
        {
            //assign the incoming parameter values to the internal fields
            //  typically you will use the properties to assign the values
            //  this will ensure that any validation within the property is executed
            Title = title; //cannot be null, empty or blank  "do not do _Ttile = title;"
            Level = level; //no validation
            StartDate = startdate; //no validation
            Years = years; //must be 0 or greater
        }

        //once again, good coding practice, all interact with
        //  data within the class should be via the property
        //Level is an auto-implement property so there is NO choice

        //  but to use the property

        //one could add validation, especially if the property has a private set

        //  OR the property

        //  is an auto-implemented property that has restrictions

        //example

        //validation, start date must not exist in the future

        //validation can be done anywhere in your class

        //since the property is auto-implemented AND/OR has a private set,

        //      validation can be done  in the constructor OR a behaviour 

        //      that alters the property

        //IF the validation is done in the property, IT WOULD NOT be an

        //      auto-implemented property BUT a fully-implemented property

        // .Today has a time of 00:00:00 AM

        // .Now has a specific time of day 13:05:45 PM

        //by using the .Today.AddDays(1) you cover all times on a specific date



        //methods


    }
}
