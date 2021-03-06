import os

def main():
    for dirpath, _, filenames in os.walk('Assets/Code'):
        for filename in filenames:
            if filename.endswith('.cs'):
                print(f'Trying file {dirpath}/{filename}')
                os.system(f'clang-format -i -style=file {dirpath}/{filename}')


if __name__ == '__main__':
    main()