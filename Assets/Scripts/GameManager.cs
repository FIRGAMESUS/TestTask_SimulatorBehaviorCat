using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Сетка кнопок (родитель)")]
    [SerializeField] private Transform grid; // Сетка кнопок
    [Header("Префаб кнопки")]
    [SerializeField] private GameObject actionButtonPrefab; // Кнопка действия
    [Header("Аниматор кошки")]
    public Animator catAnimator;
    [Header("Текстовые поля для вывода реакции и настроения")]
    [SerializeField] private TMP_Text reactionText, moodText;

    [Header("Действия, настроения и реакции")]
    [TableList]
    public List<Actions> ActionsList;



    void Start()
    {
        reactionText.text = "Реакция: ";
        moodText.text = "Настроение: "
            + ActionsList[0].Moods[Random.Range(0, ActionsList[0].Moods.Count)].currentMood; // Рандомное начальное настроение

        CreateActionButtons();
    }


    #region CreateActionButtons() - Создание кнопок исходя из доступных действий
    public void CreateActionButtons()
    {
        for (int i = 0; i < ActionsList.Count; i++)
        {
            #region Создание кнопки внутри сетки
            GameObject gameObject = Instantiate(actionButtonPrefab, grid);
            #endregion

            #region Добавление текста на кнопку
            string _action = ActionsList[i].Action;
            gameObject.transform.GetComponentInChildren<TMP_Text>().text = _action;
            #endregion

            #region Добавление метода в кнопку
            int indexOfAction = i;
            Button.ButtonClickedEvent e = new Button.ButtonClickedEvent();
            e.AddListener(() =>
            {
                DoReaction(indexOfAction);
            });
            gameObject.GetComponent<Button>().onClick = e;
            #endregion
        }
    }
    #endregion

    #region DoReaction(int indexOfAction) - Метод, который вызывается при нажатии на кнопку - выводит в текст реакцию и новое настроение и включает аниматор
    public void DoReaction(int indexOfAction)
    {
        List<MoodsWithReaction> currentMoods = ActionsList[indexOfAction].Moods;
        for (int i = 0; i < currentMoods.Count; i++)
        {
            if (moodText.text == "Настроение: " + currentMoods[i].currentMood)
            {
                reactionText.text = "Реакция: " + currentMoods[i].reaction;
                catAnimator.runtimeAnimatorController = currentMoods[i].animatorController;
                moodText.text = "Настроение: " + currentMoods[i].newMood;
            }
        }
    }
    #endregion

}

#region Действия и настроения с реакциями
[System.Serializable]
public class Actions
{
    [VerticalGroup("Действие")]
    public string Action;

    [VerticalGroup("Настроения и реакции")]
    public List<MoodsWithReaction> Moods;
}
#endregion

#region Текущее и новое настроения, реакция и аниматор к сделанному действию
[System.Serializable]
public class MoodsWithReaction
{
    [Header("Текущее настроение")]
    public string currentMood;
    [Header("Реакция")]
    public string reaction;

    [Header("Анимация")]
    public RuntimeAnimatorController animatorController;

    [Header("Новое настроение")]
    public string newMood;
}
#endregion
