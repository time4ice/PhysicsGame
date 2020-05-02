using System;
public class ProgressHandler: IDisposable
{
    private Progress _progress;

    private LocalDataController _localDataController;

    public Progress progress => _progress;

    public ProgressHandler(LocalDataController localDataController)
    {
        _localDataController = localDataController;

        Initialize();
    }

    private void Initialize()
    {
        string dataProgress = _localDataController.LoadData("Progress");

        _progress = string.IsNullOrEmpty(dataProgress) ? FillBaseProgress() : _localDataController.Deserialize<Progress>(dataProgress);
    }

    private Progress FillBaseProgress()
    {
        return new Progress()
        {
            space = new Points(0,0),
            plane =new Points(0,0)
        };
    }

    private void Save()
    {
        _localDataController.SaveData(_progress, "Progress");
    }

    public void AddSpacePoints(int points)
    {
        if(points>0)
        {
            _progress.space.wins += points;
        }

        if (points < 0)
        {
            _progress.space.looses -= points;
        }
    }

    public void AddPlanePoints(int points)
    {
        if (points > 0)
        {
            _progress.plane.wins += points;
        }

        if (points < 0)
        {
            _progress.plane.looses -= points;
        }
    }

    public void Dispose()
    {
        Save();
    }
}
