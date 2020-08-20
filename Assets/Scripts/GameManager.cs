using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform grid; // Сетка кнопок
    [SerializeField] private GameObject actionButtonPrefab; // Кнопка действия

    [SerializeField] private TMP_Text reactionText, moodText, actionText;
    private string currentAction;

    [Header("Действия, настроения и реакции")]
    public ActionList actionList;
    /*
     Action List -> Actions -> Size = количество доступных действий (Поиграть, Накормить и т.д.)
     Reactions On Action -> Size = 3 ->
                                           0 - Действие (Поиграть, Накормить и т.д.)
                                           1 - Реакция (Сидит, Бегает и т.д.)
                                           2 - Новое настроение (Плохое, Хорошее, Отличное)
    */

    void Start()
    {
        CreateActionButtons(grid, actionButtonPrefab, actionList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateActionButtons(Transform _parent, GameObject _prefab, ActionList _actionList)
    {
        foreach (var a in _actionList.actions)
        {
            GameObject gameObject = Instantiate(_prefab, _parent);
            string _action = a.reactionsOnAction[0];

            Button.ButtonClickedEvent e = new Button.ButtonClickedEvent();
            e.AddListener(() =>
            {
                DoReaction(_action);
            });

            gameObject.GetComponent<Button>().onClick = e;

            gameObject.transform.GetComponentInChildren<TMP_Text>().text = _action;
        }
    }


    public void DoReaction(string _action)
    {
        reactionText.text = _action;

        //#region moodText.text == "Плохое"
        //if (moodText.text == "Плохое" && _action == "Поиграть")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //if (moodText.text == "Плохое" && _action == "Накормить")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //if (moodText.text == "Плохое" && _action == "Погладить")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //if (moodText.text == "Плохое" && _action == "Дать пинка")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //#endregion

        //#region moodText.text == "Хорошее"
        //if (moodText.text == "Хорошее" && _action == "Поиграть")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //if (moodText.text == "Хорошее" && _action == "Накормить")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //if (moodText.text == "Хорошее" && _action == "Погладить")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //if (moodText.text == "Хорошее" && _action == "Дать пинка")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //#endregion

        //#region moodText.text == "Отличное"
        //if (moodText.text == "Отличное" && _action == "Поиграть")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //if (moodText.text == "Отличное" && _action == "Накормить")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //if (moodText.text == "Отличное" && _action == "Погладить")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //if (moodText.text == "Отличное" && _action == "Дать пинка")
        //{
        //    reactionText.text = "";
        //    moodText.text = "";
        //}
        //#endregion
    }
    public void SetMood(string _mood)
    {
        moodText.text = _mood;
    }
}


[System.Serializable]
public class Action
{
    public List<string> reactionsOnAction;
}

[System.Serializable]
public class ActionList
{
    public List<Action> actions;
}


