using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using konosuba.Helpers;
using konosuba.Models;
using System.ComponentModel;

namespace konosuba.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// 用于绑定到角色icon展示用的ListBox
        /// </summary>
        [ObservableProperty]
        BindingList<Character> characterList = [];



        /// <summary>
        /// 通过拿到的角色icon和portrait信息创建character并添加给characterList
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task Loaded()
        {
            var (Icon, Portrait) = await WebHelper.GetPictureUrl();

            for (int i = 0; i < Icon.Count; i++)
                Icon[i] = "http://konosuba.com/1st/character/" + Icon[i];

            for (int i = 0; i < Portrait.Count; i++)
                Portrait[i] = "http://konosuba.com/1st/character/" + Portrait[i];

            if (Icon.Count == Portrait.Count)
                for (int i = 0; i < Portrait.Count; i++)
                    characterList.Add(new(Icon[i], Portrait[i]));
        }

        [RelayCommand]
        void Close() =>App.Current.MainWindow.Close();
    }
}
