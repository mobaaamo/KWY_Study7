using System;
public static class GameEvents 
{
    public static event Action OnCollectibleCollected = delegate { };

   public static void CollectibleCollected()
    {
        OnCollectibleCollected();
    }
}
