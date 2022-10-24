using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;

public class AuthenicateUser : MonoBehaviour
{
    public WelcomeScreenControl welcomeScreenControl;
    public SaveLoadManager saveLoadManager;
    public User user;
    public PlayfabManager playfabManager;

    public void CreateUser(TMP_InputField email, TMP_InputField password) {
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                welcomeScreenControl.userExistsChecked = true;
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            welcomeScreenControl.continueCreateUser = true;
            user.userId = newUser.UserId;
            user.email = email.text;
            user.password = password.text;
            playfabManager.gameLoaded = true;
            playfabManager.id = newUser.UserId;
        });
    }

    public void LoadUser(TMP_InputField email, TMP_InputField password) {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                welcomeScreenControl.userDosentExistsChecked = true;
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            welcomeScreenControl.continueLoadUser = true;
            user.userId = newUser.UserId;
            user.email = email.text;
            user.password = password.text;
            playfabManager.gameLoaded = true;
            playfabManager.id = newUser.UserId;
        });
    }

    public void LoadUserFromSave(string email, string password)
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            saveLoadManager.continueLoadUser = true;
            playfabManager.gameLoaded = true;
            playfabManager.id = newUser.UserId;
        });
    }
}
