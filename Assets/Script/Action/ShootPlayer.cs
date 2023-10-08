using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class ShootPlayer : Action
{
    [SerializeField] private ActionSettings actionSettings;

    private int countBull = 0;
    public int CountBull { get { return countBull; } /*set { countBull = value; }*/ }

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform outBullet;

    [SerializeField] private ParticleSystem gunExitParticle;//система частиц

    //соберем в лист стороние скрипты

    private float shootDelay;
    private float shootTime = float.MinValue;

    //Bulls
    private List<Bull> bulls = new List<Bull>(); //тут будем хранить экз пуль   

    private void OnEnable()
    {
        shootDelay =actionSettings.ShootDelay;

        InstBulls(10);

        StartCoroutine(Example());
    }

    private void InstBulls(int count)
    {
        for (int i = 0; i < count; i++) 
        {
            GameObject bulle =Instantiate(bullet, outBullet.position, outBullet.rotation);
            Bull scriptBulle = bulle.GetComponent<Bull>();

            scriptBulle.isRun = false;
            bulls.Add(scriptBulle);
        }
    }

    public override void MoveActiv()
    {
        if (/*PhotonView.Get(this.gameObject).IsMine &&*/ IsRun)
        {
            if (RezultInput.UserInput == null)
            {
                return;
            }

            if (RezultInput.UserInput.InputData.Shoot != 0)//получим нажатие
            {
                Shoot();
            }
        }
    }

    private IEnumerator Example()
    {
        int i = 0;
        while (i < 3)
        {
            yield return new WaitForSeconds(0.2f);
            i++;
        }
    }

    private void Shoot()
    {
        if (Time.time < shootTime + shootDelay)
        {
            return;
        }
        else
        {
            shootTime = Time.time;
        }

        countBull++;
        for (int i = 0; i < bulls.Count; i++)
        {
            if (bulls[i].isRun==false)
            {
                gunExitParticle.Play();
                bulls[i].ShootBull(true, outBullet);
                TrigerCount();
                return;
            }
        }
    }
}
