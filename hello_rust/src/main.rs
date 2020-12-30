use rand::Rng;
use reqwest::Error;

fn main() {
    send_request().unwrap();
}

fn send_request() -> Result<(), Error> {
    let url = format!(
        "https://swapi.dev/api/people/{character_id}/",
        character_id = get_random_character_id()
    );
    println!("Your random Star Wars character today:");
    println!("{}", reqwest::blocking::get(&url)?.text()?);
    Ok(())
}

fn get_random_character_id() -> i8 {
    let mut id: i8;
    let mut rng = rand::thread_rng();
    loop {
        id = rng.gen_range(1..=83);
        if id != 17 {
            break;
        }
    }
    id
}
