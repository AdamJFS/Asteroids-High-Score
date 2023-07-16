using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;
    private SceneManager sceneManager;
    public GameObject[] hearts;
    LevelManager levelManager;
    public Button buttonShoot;
    public Button buttonThurst;

    public Leaderboard leaderboard;

    public float respawnTime = 2.0f;
    public float respawnInvulnerability = 2.0f;

    public int lives = 5;
    private int score = 0;
    public Text ScoreText;

    private void Start()
    {
        ScoreText.text = "SCORE: " + score.ToString();
        
    }

    public void AsteroidDestroed(Asteroid asteroid)
    {

        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();
        
        if (asteroid.size < 0.7f)
        {
            score += 10;
            ScoreText.text = "SCORE: " + score.ToString();
        }else if (asteroid.size < 1.4)
        {
            score += 5;
            ScoreText.text = "SCORE: " + score.ToString();
        } else
        {
            score += 2;
            ScoreText.text = "SCORE: " + score.ToString();
        }
        
        
    }

    [System.Obsolete]
    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        buttonShoot.enabled = false;
        buttonThurst.enabled = false;

        this.lives--;
        
        if (this.lives < 5)
        {
            Destroy(hearts[0].gameObject);
            
        }
        if (this.lives < 4)
        {
            Destroy(hearts[1].gameObject);
        }
        if (this.lives < 3)
        {
            Destroy(hearts[2].gameObject);
        }
        if (this.lives < 2)
        {
            Destroy(hearts[3].gameObject);
        }
        if (this.lives < 1)
        {
            Destroy(hearts[4].gameObject);
        }
        if (this.lives <= 0)
        {
            leaderboard.SubmitScoreRoutine(score);
            GameOverScene();
            
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    private void Respawn()
    {
        buttonShoot.enabled = true;
        buttonThurst.enabled = true;
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollision");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollision), this.respawnInvulnerability);

    }

    private void TurnOnCollision()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void GameOverScene()
    {
        FindObjectOfType<LevelManager>().GameOver();
    }

   
}
