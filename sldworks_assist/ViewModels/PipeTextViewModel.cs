using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using sldworks_assist.Models;
using sldworks_assist.Views;

namespace sldworks_assist.ViewModels
{
    public class PipeTextViewModel : ViewModel
    {
        /* コマンド、プロパティの定義にはそれぞれ 
         * 
         *  lvcom   : ViewModelCommand
         *  lvcomn  : ViewModelCommand(CanExecute無)
         *  llcom   : ListenerCommand(パラメータ有のコマンド)
         *  llcomn  : ListenerCommand(パラメータ有のコマンド・CanExecute無)
         *  lprop   : 変更通知プロパティ(.NET4.5ではlpropn)
         *  
         * を使用してください。
         * 
         * Modelが十分にリッチであるならコマンドにこだわる必要はありません。
         * View側のコードビハインドを使用しないMVVMパターンの実装を行う場合でも、ViewModelにメソッドを定義し、
         * LivetCallMethodActionなどから直接メソッドを呼び出してください。
         * 
         * ViewModelのコマンドを呼び出せるLivetのすべてのビヘイビア・トリガー・アクションは
         * 同様に直接ViewModelのメソッドを呼び出し可能です。
         */

        /* ViewModelからViewを操作したい場合は、View側のコードビハインド無で処理を行いたい場合は
         * Messengerプロパティからメッセージ(各種InteractionMessage)を発信する事を検討してください。
         */

        /* Modelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedEventListenerや
         * CollectionChangedEventListenerを使うと便利です。各種ListenerはViewModelに定義されている
         * CompositeDisposableプロパティ(LivetCompositeDisposable型)に格納しておく事でイベント解放を容易に行えます。
         * 
         * ReactiveExtensionsなどを併用する場合は、ReactiveExtensionsのCompositeDisposableを
         * ViewModelのCompositeDisposableプロパティに格納しておくのを推奨します。
         * 
         * LivetのWindowテンプレートではViewのウィンドウが閉じる際にDataContextDisposeActionが動作するようになっており、
         * ViewModelのDisposeが呼ばれCompositeDisposableプロパティに格納されたすべてのIDisposable型のインスタンスが解放されます。
         * 
         * ViewModelを使いまわしたい時などは、ViewからDataContextDisposeActionを取り除くか、発動のタイミングをずらす事で対応可能です。
         */

        /* UIDispatcherを操作する場合は、DispatcherHelperのメソッドを操作してください。
         * UIDispatcher自体はApp.xaml.csでインスタンスを確保してあります。
         * 
         * LivetのViewModelではプロパティ変更通知(RaisePropertyChanged)やDispatcherCollectionを使ったコレクション変更通知は
         * 自動的にUIDispatcher上での通知に変換されます。変更通知に際してUIDispatcherを操作する必要はありません。
         */
        #region 面1の穴の数
        private object _Demention1data;

        public object Demention1data
        {
            get { return this._Demention1data; }
            set
            {
                if (this._Demention1data != value)
                {
                    this._Demention1data = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region FilePath変更通知プロパティ
        private string _FilePath;

        public string FilePath
        {
            get { return this._FilePath; }
            set
            {
                if (this._FilePath != value)
                {
                    this._FilePath = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 経(一覧)の変更通知プロパティ
        private int[] _AllKei;

        public int[] AllKei
        {
            get { return this._AllKei; }
            set
            {
                if(this._AllKei != value)
                {
                    this._AllKei = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region Length 変更通知プロパティ
        private string _Length;

        public string Length
        {
            get { return this._Length; }
            set
            {
                if (this._Length != value)
                {
                    this._Length = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 経の変更通知プロパティ
        private int _Kei;

        public int Kei
        {
            get { return this._Kei; }
            set
            {
                if(this._Kei != value)
                {
                    this._Kei = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        #endregion

        public void Initialize()
        {
            
        }

        public PipeTextViewModel()
        {
            FilePath = @"C:\sldWorks\Part\newPart1.sldprt";
            AllKei = new int[]{9,10,12,15,20};
            Kei = 0;
            Length = "100";
        }

        public void Demention1Text()
        {
            
        }

        public void ChangePathRun()
        {

            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.FileName = "newpart.sldprt";
            sfd.InitialDirectory = @"C:\";
            sfd.Filter =
                "すべてのファイル(*.*)|*.*";
            sfd.Title = "保存先のファイルを選択してください";
            sfd.RestoreDirectory = true;

            if ((bool)sfd.ShowDialog())
            {
                FilePath = sfd.FileName;
                Run();
            }
        }

        public void Run()
        {
            Core core = new Core();
            int kei = AllKei[Kei];
            core.CreatePipe(FilePath, kei,Length);
        }

    }
}
