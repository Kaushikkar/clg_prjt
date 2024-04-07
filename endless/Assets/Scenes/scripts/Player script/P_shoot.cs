using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public EnemyDetection enemy;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public int maxBullets = 30;
    public float fireRate = 0.1f;
    public float reloadTime = 2f;
    public bool canShoot;
    private int bulletsRemaining;
    public bool isReloading = false;
    public float bulletSpeed;
    public Vector3 offset;
    private float timeSinceLastShot = 0f;
    public float bulletDespawnTime = 5f; // Adjust this as needed
    public int damage = 1;

    // Add this field for the sound effect
    public AudioClip shootSound;
    private AudioSource audioSource;

    // Volume control
    public float volume = 1.0f; // Default volume

    private void Start()
    {
        bulletsRemaining = maxBullets;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        canShoot = enemy.enemiesFound;

        // Calculate time since the last shot
        timeSinceLastShot += Time.deltaTime;

        if (bulletsRemaining > 0 && canShoot && !isReloading && timeSinceLastShot >= fireRate)
        {
            InstantiateBullet();
            bulletsRemaining -= 1;
            timeSinceLastShot = 0f; // Reset the time since the last shot
        }
        else if (bulletsRemaining == 0 && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        //Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        bulletsRemaining = maxBullets;
        isReloading = false;
    }

    void InstantiateBullet()
    {
        // Use the rotation of the bulletSpawnPoint to instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position + offset, bulletSpawnPoint.rotation);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Use the bullet's forward direction, based on its own rotation
        bulletRb.velocity = bulletSpeed * bullet.transform.forward;

        // Start coroutine to despawn the bullet after a certain time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletDespawnTime));

        // Play the shoot sound effect with adjusted volume
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound, volume);
        }
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    // Method to adjust the volume
    public void SetVolume(float newVolume)
    {
        volume = newVolume;
    }
}
