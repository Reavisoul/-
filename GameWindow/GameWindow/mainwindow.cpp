#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QProcess>



MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    QImage image1(":/game/Birds.jpg");//filename，图片的路径名字
    ui->label->setPixmap(QPixmap::fromImage(image1));//
    ui->label->setScaledContents(true);
    ui->label->show();

    QImage image2(":/game/Tanks.jpg");//filename，图片的路径名字
    ui->label_2->setPixmap(QPixmap::fromImage(image2));//
    ui->label_2->setScaledContents(true);
    ui->label_2->show();

    QImage image3(":/game/Sweets.jpg");//filename，图片的路径名字
    ui->label_3->setPixmap(QPixmap::fromImage(image3));//
    ui->label_3->setScaledContents(true);
    ui->label_3->show();



}

MainWindow::~MainWindow()
{
    delete ui;
}



void MainWindow::on_pushButton_clicked()
{

    if(ui->pushButton->text() == "愤怒的小鸟")
    {
        QProcess *myProcess = new QProcess();
        myProcess->start("F:/MyGame/Angry_Birds/Angry_Birds.exe");//打开游戏
        ui->pushButton->setText("关闭游戏");
    }
    else if(ui->pushButton->text() == "关闭游戏")
    {
      QString c = "taskkill /im Angry_Birds.exe /f";
      QProcess::execute(c);//关闭游戏
      ui->pushButton->setText("愤怒的小鸟");
    }
}
void MainWindow::on_pushButton_2_clicked()
{

    if(ui->pushButton_2->text() == "坦克大战")
    {
        QProcess *myProcess = new QProcess();
        myProcess->start("F:/MyGame/Tank_War/Tank_War.exe");//打开游戏
        ui->pushButton_2->setText("关闭游戏");
    }
    else if(ui->pushButton_2->text() == "关闭游戏")
    {
      QString c = "taskkill /im Tank_War.exe /f";
      QProcess::execute(c);//关闭游戏
      ui->pushButton_2->setText("坦克大战");
    }
}

void MainWindow::on_pushButton_3_clicked()
{

    if(ui->pushButton_3->text() == "甜品消消乐")
    {
        QProcess *myProcess = new QProcess();
        myProcess->start("F:/MyGame/Creash_Sweets/Creash_Sweets.exe");//打开游戏
        ui->pushButton_3->setText("关闭游戏");
    }
    else if(ui->pushButton_3->text() == "关闭游戏")
    {
      QString c = "taskkill /im Creash_Sweets.exe /f";
      QProcess::execute(c);//关闭游戏
      ui->pushButton_3->setText("甜品消消乐");
    }
}


void MainWindow::on_comboBox_currentTextChanged(const QString &arg1)
{
    if(arg1=="愤怒的小鸟")
    {
        ui->label->setVisible(false);ui->pushButton->setVisible(false);
    }
    else if(arg1=="坦克大战")
    {
        ui->label_2->setVisible(false);ui->pushButton_2->setVisible(false);
    }
    else if (arg1=="甜品消消乐")
    {
        ui->label_3->setVisible(false);ui->pushButton_3->setVisible(false);
    }

}



void MainWindow::on_comboBox_2_currentTextChanged(const QString &arg1)
{
    if(arg1=="愤怒的小鸟")
    {
        ui->label->setVisible(true);ui->pushButton->setVisible(true);
    }
    else if(arg1=="坦克大战")
    {
        ui->label_2->setVisible(true);ui->pushButton_2->setVisible(true);
    }
    else if (arg1=="甜品消消乐")
    {
        ui->label_3->setVisible(true);ui->pushButton_3->setVisible(true);
    }
}



