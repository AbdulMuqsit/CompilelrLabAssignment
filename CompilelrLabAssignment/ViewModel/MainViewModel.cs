using CompilelrLabAssignment.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompilelrLabAssignment.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _input;

        public string Input
        {
            get { return _input; }
            set
            {
                if (_input == value)
                {
                    return;
                }
                _input = value;
                OnPropertyChanged();
                ParseInput();

            }
        }

        private async void ParseInput()
        {
            await Task.Run(() =>
            {
                if (String.IsNullOrWhiteSpace(Input))
                {
                    OutPut = String.Empty;
                    return;
                }
                if (Regex.IsMatch(Input, @"^(\d+)(.)(\d+)$"))
                {
                    OutPut = "Float literal";

                }
                else if (Regex.IsMatch(Input, @"^(\d+)$"))
                {
                    if ((new Func<bool>(() => { try { return Convert.ToInt32(Input) < 2_147_483_647; } catch { return false; } }))())
                    {
                        OutPut = "Integer Constant";

                    }
                    else
                    {
                        OutPut = "Out of range integer";
                    }
                }
                else if (Regex.IsMatch(Input, "^((int)|(float)|(char)|(double)|(if)|(else)|(while)|(do)|(switch))$"))
                {
                    OutPut = "Language keyword";
                }
                else if (Regex.IsMatch(Input, "^[_a-zA-Z]([_a-zA-Z]*[0-9]*)*$"))
                {
                    OutPut = "Variable Identifier";
                }
                else if (Regex.IsMatch(Input, @"^((\+)|(\*)|(/)|(-))$"))
                {
                    OutPut = "Arithmetic Operator";
                }
                else if (Regex.IsMatch(Input, "^((==)|(!=)(<=)|(>=)(<)|(>))$"))
                {
                    OutPut = "Relational Operator";
                }
                else if (Regex.IsMatch(Input, "^((&&)|(||)|(!))$"))
                {
                    OutPut = "Logical Operator";
                }
                else if (Regex.IsMatch(Input, @"^((&)|(\|)|(~))$"))
                {
                    OutPut = "Binary Operator";
                }
                else
                {
                    OutPut = "Invalid Input";
                }
            });
        }

        private string _outPut;

        public string OutPut
        {
            get { return _outPut; }
            set
            {
                if (_outPut == value)
                {
                    return;
                }
                _outPut = value;
                OnPropertyChanged();
            }
        }
    }
}
