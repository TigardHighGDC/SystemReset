import os

if __name__ == '__main__':
    # Search through all nested folders in the Assets/Code folder
    # If the file is a .cs file format it with clang-format
    for dirpath, _, filenames in os.walk('Assets/Code'):
        for filename in filenames:
            if filename.endswith('.cs'):
                print(f'Trying file {dirpath}/{filename}')
                os.system(f'clang-format -i -style=file {dirpath}/{filename}')