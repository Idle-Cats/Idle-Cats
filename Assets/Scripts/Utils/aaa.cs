using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class aaa : TMP_InputValidator
{
    public override char Validate(ref string text, ref int pos, char ch){
        if (!char.IsLetter(ch) && !char.IsDigit(ch) && ch != '_') {
            return '\0';
        }
        return ch;
    }

}
