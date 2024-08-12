using UnityEngine;
using UnityEngine.UI;
public class CharacterSelectManager : MonoBehaviour
{
    public GameObject HuggyPlayer;
    public GameObject JumboPlayer; 
    public GameObject HuggyEnemy;
    public GameObject JumboEnemy;

    public Transform playerSpawnPoint; // V? tr� spawn c?a ng�?i ch�i
    public Transform enemySpawnPoint;  // V? tr� spawn c?a k? th�

    public Image playerIcon; 
    public Image enemyIcon;

    public Sprite HuggyIcon;
    public Sprite JumboIcon; 

    void Start()
    {

        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");

        if (string.IsNullOrEmpty(selectedCharacter))
        {

            selectedCharacter = "HuggyPlayer"; 
        }

        GameObject player = null;
        GameObject enemy = null;

        if (selectedCharacter == "HuggyPlayer")
        {
            player = Instantiate(HuggyPlayer, playerSpawnPoint.position, HuggyPlayer.transform.rotation);
            enemy = Instantiate(JumboEnemy, enemySpawnPoint.position, JumboEnemy.transform.rotation);
            //change heath icon
            playerIcon.sprite = HuggyIcon;
            enemyIcon.sprite = JumboIcon;

        }
        else if (selectedCharacter == "JumboPlayer")
        {
            player = Instantiate(JumboPlayer, playerSpawnPoint.position, JumboPlayer.transform.rotation);
            enemy = Instantiate(HuggyEnemy, enemySpawnPoint.position, HuggyEnemy.transform.rotation);
            playerIcon.sprite = JumboIcon;
            enemyIcon.sprite = HuggyIcon;

        }
    }
}
