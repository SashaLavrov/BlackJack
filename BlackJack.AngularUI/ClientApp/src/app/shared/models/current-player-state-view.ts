export class CurrentPlayerStateView {
    roundNumber: number;
    playerId: number;
    playerName: string;
    isBot: boolean;
    totalCount: number;
    cards: Array<CurrentCardPlayerStateViewItem>[];

    isWin: boolean;
}

export class CurrentCardPlayerStateViewItem {
    cardId: number;
    value: number;
    type: string;
    suit: string;
}
