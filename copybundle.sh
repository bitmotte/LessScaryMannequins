firstattempt=true
userpath=""

prompt_path() {
    echo ""
    read userpath
    if [ -d "$userpath/Assets" ]; then
        echo "found ! ! !"
    else
        echo "invalid path! ! !"
        if [ "$firstattempt" = true ]; then
            echo ""
            echo "tip: make sure that you input the ROOT"
            echo "unity path, NOT the assets folder."
            firstattempt=false
        fi
        echo ""
        prompt_path
    fi
}

if [ -a "./resources/copybundlesettings" ]; then
    echo "settings found"
else
    echo "no settings found ! ! ! must make them"
    echo "setting 1: type the path for your unity folder:"
    prompt_path
    echo "making settings file. . ."
    touch "./resources/copybundlesettings"
    printf "$userpath" >> "./resources/copybundlesettings"
fi

echo ""
echo "finding bundle. . ."

userpath=$(< "./resources/copybundlesettings" )
currentdir=$(pwd)

cd ${userpath}Library/com.unity.addressables/aa/Windows/StandaloneWindows64/

bundle=$(find . -maxdepth 1 -name "*defaultlocalgroup*")
bundle=${bundle#./}

cd ${currentdir}

echo "copying unity bundle to project resources"
cp "${userpath}Library/com.unity.addressables/aa/Windows/StandaloneWindows64/${bundle}" "./resources/copy.bundle" 
echo "done! ! !"
