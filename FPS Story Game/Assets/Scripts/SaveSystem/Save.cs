[System.Serializable]
public class Save {

    public float[] position;
    public float[] rotation;

    public Save(Player player) {
        var position1 = player.transform.position;
        position = new float[3] {

            position1.x,
            position1.y,
            position1.z,

        };

        rotation = new float[4] {

            player.playerCamera.transform.rotation.x,
            player.playerCamera.transform.rotation.w,
            player.transform.rotation.y,
            player.transform.rotation.w,

        };

    }
    
}