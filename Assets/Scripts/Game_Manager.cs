using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public int coinsToCollect;
    public int coinsCollected;

    public Dialogue_SO allCoinsDialogue;
    public NPC_Controller coinsNPC;

    private void Update()
    {
        if(coinsCollected >= coinsToCollect)
        {
            coinsNPC.starterDialogue = allCoinsDialogue;
        }
    }
}
