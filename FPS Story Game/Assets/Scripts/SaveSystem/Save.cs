[System.Serializable]
public class Save {

    public float[] position;
    public float[] rotation;

    public Save(Player player) {

        position = new float[3] {

            player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z,

        };

        rotation = new float[4] {

            player.playerCamera.transform.rotation.x,
            player.playerCamera.transform.rotation.w,
            player.transform.rotation.y,
            player.transform.rotation.w,

        };

    }
    
}