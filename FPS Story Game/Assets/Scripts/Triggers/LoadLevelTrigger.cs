using UnityEngine;
using UnityEngine.SceneManagement;

class LoadLevelTrigger : Trigger {

    public int levelIndex;

    public override void Enter(Collider other) {

        SceneManager.LoadScene(levelIndex);

    }

}